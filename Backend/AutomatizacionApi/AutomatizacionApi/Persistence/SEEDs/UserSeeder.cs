using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Domain.Entities.User;
using AutomatizacionApi.Domain.Enum;
using AutomatizacionApi.Persistence.Context.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutomatizacionApi.Persistence.SEEDs
{
    public static class UserSeeder
    {
        public async static Task Seed(IdentityContext context,
                    IUserRepository userRepository,
                    UserManager<ApplicationUser> userManager)
        {

            var user = await context.Set<ApplicationUser>().AnyAsync();
            if (user)
                return;

            var customer = new Customer
            {
                FirstName = "Manuel",
                LastName = "Gonzalez",
                Email = "manuelgonzalez@gmail.com",
                Cedula = "12345678901",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                UserName = "ManuelGonza",
                PhoneNumberConfirmed = true,
            };

            var driver = new Driver
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johnDoe@gmail.com",
                Cedula = "12345678901",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                UserName = "JohnDoe",
                PhoneNumberConfirmed = true,
                License = "12345678901",
            };

            var admin = new Admin
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@gmail.com",
                Cedula = "12345678901",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                UserName = "Admin",
                PhoneNumberConfirmed = true,
            };

            var users = new List<ApplicationUser>()
            {
                customer,
                driver,
                admin
            };

            foreach (var userToAdd in users)
            {
                // Add each user sequentially to avoid threading issues
                await userRepository.Add(userToAdd, "Time!1244Roman.djw");
                if (userToAdd is Customer)
                {
                    await userManager.AddToRoleAsync(userToAdd, Roles.Customer.ToString());
                }
                else if (userToAdd is Driver)
                {
                    await userManager.AddToRoleAsync(userToAdd, Roles.Driver.ToString());
                }
                else if (userToAdd is Admin)
                {
                    await userManager.AddToRoleAsync(userToAdd, Roles.Admin.ToString());
                }

            }
        }
    }
}
