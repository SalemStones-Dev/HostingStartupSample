# HostingStartupSample
This is a sample project to demonstrate an error I'm seeing in trying to use hosting startup assemblies in .NET 6.0 (preview 7).

## Solution Overview
1. Api - A minimal API ASP.NET Core 6.0 application  
The only changes from what's generated via "dotnet new" is the lambda that's used to implement the "/" route.
1. Interfaces - The definition of an interface used to implement the "/" route
1. Library - A class library which is attempting to leverage the hosting startup features  
It has the [assembly: HostingStartup] attribute and an implementation of IHostingStartup
1. The command line argument --hostingStartupAssemblies=Library is passed to the Api project  
Note that Api has a project dependency on the Library project to ensure that Library.dll is copied to the Api's bin/Debug/net6.0 folder

## Problem Statement
The only evidence that the Library assembly is being loaded is this log message:

```plaintext
dbug: Microsoft.AspNetCore.Hosting.Diagnostics[13]
      Loaded hosting startup assembly Library
```

This message seems to indicate that the --hostingStartupAssembiles argument is being recognized.

However, the LibraryStartup class which implements IHostingStartup is never called. Consequently, when the app is run and the "/" route is requested, an exception is generated with the message:

No service for type 'Interface.IHandler' has been registered.
