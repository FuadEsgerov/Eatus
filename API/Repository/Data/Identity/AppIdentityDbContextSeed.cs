using Microsoft.AspNetCore.Identity;
using Repository.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Fuad",
                    Email = "fuad@test.com",
                    UserName = "fuad@test.com",
                    Address = new Address
                    {
                        FirstName = "Fuad",
                        LastName = "Asgarov",
                        Street = "Sharifzade",
                        City = "Baku",
                        State = "Yasamal",
                        Zipcode = "Az1000"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
