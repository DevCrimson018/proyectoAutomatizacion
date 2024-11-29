using AutomatizacionApi.Interfaces.Repositories;

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
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new()
                {
                    Name = "Customer",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new()
                {
                    Name = "Driver",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            };

            // Add roles to the database in parallel
            var tasks = roles.Select(role => roleRepository.Add(role)).ToList();
            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
     
        }
    }
}
