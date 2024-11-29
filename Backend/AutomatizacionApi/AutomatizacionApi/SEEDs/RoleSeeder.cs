﻿using AutomatizacionApi.Interfaces.Repositories;
using AutomatizacionApi.Repositories;

namespace AutomatizacionApi.SEEDs
{
    public class RoleSeeder
    {
        public async static Task Seed(IRoleRepository roleRepository)
        {
            var role = await roleRepository.GetAllAsync();
            if (role.Count > 0)
                return;

            var roles = new List<Entities.User.ApplicationRole>
            {
                new() {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new()
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new()
                {
                    Name = "Driver",
                    NormalizedName = "DRIVER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            };

            foreach (var roleToAdd in roles)
            {
                await roleRepository.Add(roleToAdd);
            }

        }
    }
}
