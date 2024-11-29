using AutomatizacionApi;
using AutomatizacionApi.Context.Identity;
using AutomatizacionApi.Entities.User;
using AutomatizacionApi.Interfaces.Repositories;
using AutomatizacionApi.SEEDs;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddIdentityLayer(builder.Configuration);

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


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IdentityContext>();
    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleRepository = scope.ServiceProvider.GetRequiredService<IRoleRepository>();
    await RoleSeeder.Seed(roleRepository);
    await UserSeeder.Seed(context, userRepository, userManager);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
