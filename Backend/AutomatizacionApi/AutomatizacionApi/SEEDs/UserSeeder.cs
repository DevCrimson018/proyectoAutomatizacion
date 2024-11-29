using AutomatizacionApi.Interfaces.Repositories;

namespace AutomatizacionApi.SEEDs
{
    public static class UserSeeder
    {
        public async static Task Seed(IUserRepository userRepository)
        {

            //var user = await userRepository.GetByEmail("manuel@gmail.com");
            //if (user is not null)
            //    return;


            //await userRepository.Add(
            //    new Entities.ApplicationUser
            //    {
            //        Email = "manuel@gmail.com",
            //        UserName = "Manuel",
            //        PhoneNumber = "1234567890",
            //    }, "Time!1244Roman.djw");
        }
    }
}
