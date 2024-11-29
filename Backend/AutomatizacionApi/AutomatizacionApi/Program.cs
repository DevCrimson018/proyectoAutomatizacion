using AutomatizacionApi;
using AutomatizacionApi.Interfaces.Repositories;
using AutomatizacionApi.SEEDs;
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
    //var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    //var roleRepository = scope.ServiceProvider.GetRequiredService<IRoleRepository>();
    //await UserSeeder.Seed(userRepository);
    //await RoleSeeder.Seed(roleRepository);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
