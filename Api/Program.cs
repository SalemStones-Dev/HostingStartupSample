using Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Runtime.Versioning;

Console.WriteLine($"Target Framework: {Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName!}");
Console.WriteLine($"Startup assemblies: {Environment.GetEnvironmentVariable("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES")}");

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", ([FromServices] IHandler handler) => handler.HandleRequest("Hello World!"));

var assemblies = AppDomain.CurrentDomain.GetAssemblies();

app.Run();
