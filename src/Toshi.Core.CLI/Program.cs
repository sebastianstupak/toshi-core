using Cocona;
using Toshi.Core.CLI;

var builder = CoconaApp.CreateBuilder();

// TODO: Add services

var app = builder.Build();

app.AddCreateDatabaseCommand();

app.Run();