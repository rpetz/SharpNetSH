# SharpNetSH
A simple netsh library for C#

#####NuGet Installation:

    Install-Package SharpNetSH

This library is designed to provide easy access to the NetSH tool from inside of your C# application.  Currently the library only supports some NetSH contexts, but other contexts will be added in to support the remainder of the functionality as time permits.  See the `Current NetSH Context Support` section for information on what is supported currently.

##Usage

The library utilizes a fluent API that mimics the structure of command line netsh calls.

For example - given the following command line:

    netsh http show sslcert ipport=0.0.0.0:1234

You would write the following:

    NetSH.CMD.Http.Show.SSLCert("0.0.0.0:1234");

All objects respond with a `StandardResponse` object which denotes the exit code, whether or not it was a normal exit condition, the raw data that was returned, and a dynamic object that was parsed with a standardized output parser - *See the `Preface` for more information as to why it is standardized*

The `NetSH.CMD` command instantiates a new instance of the default NetSH object, utilizing the `CommandLineHarness` for execution.  Execution harnesses are what take a NetSH command and do something with them.  If you wish to use a different execution harness, simply instantiate the NetSH object directly:

    var netsh = new NetSH(new CommandLineHarness());
    netsh.Http.Show.SSLCert("0.0.0.0:1234");

If you wish to write your own execution harness simply implement the `Ignite.SharpNetSH.IExecutionHarness` interface.  We also provide a `ConsoleLogHarness` which simply directs your command output to `Console.WriteLine` calls.

We have commented each method call with text directly from its MSDN counterpart, along with links to the original MSDN source pages.  As such, to explore the various contexts and actions, simply check out your type ahead for detailed information.

##Preface

The library is built with a Convention over Configuration mentality.  NetSH is a massive tool with a large number of dynamic responses based not only upon which parameters were provided but also what data it has to give.  As such, the library utilizes a standardized convention to interact with NetSH and a standardized convention to parse the response data.  All method calls come back with a standard NetSHResponse object which details whether or not the response was a standard exit code, the exit code itself, and a dynamic C# object which parses the output from NetSH.  As such, you will not have compile time checking on the response objects unless you build your own object with the data you care about and cast the dynamic to that object.

###Input Conventions

Interfaces are defined and annotated for all currently defined NetSH methods.  These have been configured to output all of the correct text for each method call in NetSH using attributes that convert C# naming conventions into the appropriate output text.  These interfaces are then applied to a Dynamic Proxy class that can process the method calls and fire the provided IExecutionHarness (which normally should be the provided CommandLineHarness), then process the output.  This allows for the methods to be processed entirely as an interface, without ever writing a single concrete class to define the method call.

###Output Conventions

NetSH appears to have a standardized output structure.  Tabbing is used to indicate whether or not the current line of text belongs to a prior line of text that is tabbed one tabulation character less.  Blank lines are intermittently used to break 'chunks' of data into repeated objects, sometimes using headings of a particular tabulation to break apart chunks instead.  The parsing convention to use is supplied by an attribute on the method call and is determined based upon what is observed behavior from NetSH.  We aggregate similar data blocks wherever we can, and rely upon simple C# dynamic parsing everywhere else.

##Gotchas

This system is highly reliant upon convention.  As I stated before, hand writing custom classes and output parsers for every NetSH call would be impossible and a maintenance nightmare.  As a result, I've carefully built several standardized parsers to process data.  Unfortunately, the data that comes back from `netsh` isn't necessarily designed for OOP.  Beacuse of this there are a few things to watch out for when coding for your response:

####Collections are not always type safe

A prime example of this can be seen by running the following command from your command line: `netsh http show servicestate view=session`  In the output you will see several `Server Session ID` blocks, followed by a `Request Queues` block.  When we parse the data, we see root objects (those without tab indentation) as individual objects in a collection.  Because there is no heading saying 'Server Sessions:' before the `Server Session ID` blocks, we have no way of knowing that we need to roll those objects into a collection that does not include the `Request Queues` block.  As such, be aware that **anytime** you are looping through a collection object the elements may not always be of the same type.

**NOTE**: While this is true, there are several cases where we actually recognized repetition in the object titles and roll them into a collection that can be considered as 'type safe'.  If a better implementation is written in the future we might be able to guarantee type-safety.

####Objects are highly dynamic

Each object that is returned by netsh has slight nuances about it.  Some use 'Yes/No' values for booleans, other 'Enabled/Disabled' or 'True/False'.  These are easy for us to compensate for and we provide you back with a true boolean object in these situations.  However, many responses handle things wildly different - for example, null handling is sometimes represented with a string '(null)' value that we parse as `NULL`, while other times the entry is left out entirely.  As a result, you should *always* assume that the values you are looking at could possibly be null.

####Dynamic object structures can change from release to release

Since we utilize a standardized set of output parsers, minor changes to them can have drastic effects on the dynamic objects that we return back.  As such, we highly recommend that you test your code when updating the NuGet package.  We also highly recommend that you mark your NuGet dependency to a specific version, rather than any version greater-than-or-equal-to a specific version - especially if working in a team environment.

**RECOMMENDATION**: If you are highly reliant upon response objects, we recommend building a concrete object that grabs the data you care about and then writing a method to instantiate a new instance of that object from our dynamic response object.  This allows your code to maintain a weak-reference to our dynamic objects, which makes it much easier to patch things if and when our object structures change.

####Exit codes are your friend

Most NetSH actions do not provide you with data, but rather add/remove/update values.  If you are utilizing an action like this stick with checking the `StandardResponse.ExitCode` and `StandardResponse.IsNormalExit` values instead of checking the actual text coming back.  Exit codes are highly reliable and often times can be directly mapped to an Enum that lists exactly what happened.  **Matching string literals with the dynamic ResponseObject's data is not recommended.**

##Dependencies

######[Humanizer](https://github.com/MehdiK/Humanizer) - Latest Version

In order to properly build objects, we have to be able to pluralize words when possible.  For instance, when calling `[netSH].Http.Show.UrlAcl()` it provides a list of Reserved URLs, each with a list of Users that are assigned capabilities on those URLs.  When we parse this object, the sub-list of Users gets created because each user block can be grouped together by its title of `User`.  As a result we take this title, pluralize it, assign it an IEnumerable object, and then place each User object into that collection.  We could recreate this code ourselves, but it is beyond the scope of this project and as such we bring in Humanizer.

##Contribution

NetSH contains a massive amount of contexts and actions - as such we have implemented each of them as we have needed them.  If you wish to contribute, we would be greatly appreciative - simply provide us with a Pull Request and we will let you know if there is anything we need to update before we commit it in.  Please note the following conventions before initiating your pull request:

- We prefer the usage of 'var' instead of directly decalaring the object type - consistency in any project is a good thing
- We have carefully encapsulated our code to provide a streamlined public API.  If you are adding in a context, feel free to make it `public` - but if you are operating on anything that the user does not directly invoke please keep it `internal`
- We are big fans of Test Driven Development and would like to continue that pattern.  We understand if you don't have time, but before we pull code in we will discuss writing tests for it first.
- If you are implementing an `internal interface` on a `public` class, please use explicit references:  (i.e. `void ISampleInterface.SampleMethod()` instead of `public void SampleMethod`)  This ensures that privately facing interfaces are not exposing their functionality to the public API.

##Current NetSH Context Support

######NOTE: Current support is highly limited, however it will be expanded upon very rapidly.  Adding in contexts is a very trivial task, however it generally requires a fair amount of time to complete.  If you have a specific context you would like to utilize, please open up an issue on the GitHub page and that will make it a priority.

          Context          Status
        - add            - Not Supported
        - advfirewall    - Not Supported
        - branchcache    - Not Supported
        - bridge         - Not Supported
        - delete         - Not Supported
        - dhcpclient     - Not Supported
        - dnsclient      - Not Supported
        - dump           - Not Supported
        - exec           - Not Supported
        - firewall       - Not Supported
        - help           - Not Supported
        - http           - Fully Supported
        - interface      - Not Supported
        - ipsec          - Not Supported
        - lan            - Not Supported
        - mbn            - Not Supported
        - namespace      - Not Supported
        - nap            - Not Supported
        - netio          - Not Supported
        - p2p            - Not Supported
        - ras            - Not Supported
        - rpc            - Not Supported
        - set            - Not Supported
        - show           - Not Supported
        - trace          - Not Supported
        - wcn            - Not Supported
        - wfp            - Not Supported
        - winhttp        - Not Supported
        - winsock        - Not Supported
        - wlan           - Not Supported
