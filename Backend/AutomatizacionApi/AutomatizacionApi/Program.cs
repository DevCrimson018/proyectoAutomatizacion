using AutomatizacionApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddIdentityLayer(builder.Configuration);
builder.Services.AddMainContext(builder.Configuration);

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddSwaggerGen();

builder.Configuration
    .AddJsonFile("appsettings.json", false)
    .AddJsonFile("appsettings.Development.json", true)
    .AddUserSecrets(Assembly.GetEntryAssembly()!)
    .AddEnvironmentVariables();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
