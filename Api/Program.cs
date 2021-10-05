using Interface;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", ([FromServices] IHandler handler) => handler.HandleRequest("Hello World!"));

app.Run();
