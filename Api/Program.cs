using Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Runtime.Versioning;

// See: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/platform-specific-configuration?view=aspnetcore-6.0
// Also see Twitter thread: https://twitter.com/adhalejr/status/1444035731073212421?s=20
//
// Previous asp.net core versions and the docs linked above (as of 2021-10-05) indicate that other
// mechanisms besides an environment variable should cause hosting startup assemblies to be loaded.
// But as of .NET 6.0 / ASP.NET Core 6.0 RC1, that's not the case.
//
// This environment variable causes the call to "CreateBuilder" to load the specified
// hosting startup assemblies and call their IHostingStartup implementations.
Environment.SetEnvironmentVariable("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES", "Library");

Console.WriteLine($"Target Framework: {Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName!}");
Console.WriteLine($"Startup assemblies: {Environment.GetEnvironmentVariable("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES")}");

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", ([FromServices] IHandler handler) => handler.HandleRequest("Hello World!"));

app.Run();
