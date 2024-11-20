using GlobalWeb.Api;
using GlobalWeb.Api.Extensions;
using GlobalWeb.Application;
using GlobalWeb.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGenWithAuth();
builder.Services.AddApplication().AddPresentation().AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthentication();
app.MapControllers();

app.Run();
