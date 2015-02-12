# SharpNetSH
A simple netsh library for C#

#####NuGet Installation:

    Install-Package SharpNetSH

This library is designed to provide easy access to the NetSH tool from inside of your C# application.  Currently the library only supports some NetSH contexts, but other contexts will be added in to support the remainder of the functionality as time permits.  See the table below for information on what is supported currently.

The library is built with a Convention over Configuration mentality.  NetSH is a massive tool with a large number of dynamic responses based not only upon which parameters were provided but also what data it has to give.  As such, the library utilizes a standardized convention to interact with NetSH and a standardized convention to parse the response data.  All method calls come back with a standard NetSHResponse object which details whether or not the response was a standard exit code, the exit code itself, and a dynamic C# object which parses the output from NetSH.  As such, you will not have compile time checking on the response objects unless you build your own object with the data you care about and cast the dynamic to that object.

###Input Conventions

Interfaces are defined and annotated for all currently defined NetSH methods.  These have been configured to output all of the correct text for each method call in NetSH using attributes that convert C# naming conventions into the appropriate output text.  These interfaces are then applied to a Dynamic Proxy class that can process the method calls and fire the provided IExecutionHarness (which normally should be the provided CommandLineHarness), then process the output.  This allows for the methods to be processed entirely as an interface, without ever writing a single concrete class to define the method call.

###Output Conventions

NetSH appears to have a standardized output structure.  Tabbing is used to indicate whether or not the current line of text belongs to a prior line of text that is tabbed one tabulation character less.  Blank lines are intermittently used to break 'chunks' of data into repeated objects, sometimes using headings of a particular tabulation to break apart chunks instead.  The parsing convention to use is supplied by an attribute on the method call and is determined based upon what is observed behavior from NetSH.  We aggregate similar data blocks wherever we can, and rely upon simple C# dynamic parsing everywhere else.

###Current NetSH Context Support

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
