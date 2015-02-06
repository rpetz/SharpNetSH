# SharpNetSH
A simple netsh library for C#

#####This is version 1.0, and theoretically should work with all NetSH commands, however I have not yet tested them all and currently it only supports execute-only (I.E. none of the NetSH.Http.Show commands will return anything back at the moment)

###TODO

- Allow multiple harnesses to be registered and retain registration order
- Finish ShowAction responses
- Finish AddAction responses
- Finish DeleteAction responses
- Need to handle error cases (like adding an existing IP Address to Http.Add.IpListen)
