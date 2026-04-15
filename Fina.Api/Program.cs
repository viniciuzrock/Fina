using Fina.Api;
using Fina.Api.Common.Api;
using Fina.Api.Data;
using Fina.Api.Endpoints;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDataContext();
builder.AddCrossOrigin();
builder.AddDocumentation();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnviorment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();

app.Run();
