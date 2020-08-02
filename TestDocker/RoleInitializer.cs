using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string directorEmail = "Director";
            string directorPassword = "Trader25";

            string storekeeperEmail = "Storekeeper";
            string storekeeperPassword = "Trader25";

            string managerEmail = "Manager"; 
            string managerPassword = "Trader25";

            string accountantEmail = "Accountant";
            string accountantPassword = "Trader25";

            if (await roleManager.FindByNameAsync("director") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("director"));
            }

            if (await roleManager.FindByNameAsync("storekeeper") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("storekeeper"));
            }

            if (await roleManager.FindByNameAsync("manager") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("manager"));
            }

            if (await roleManager.FindByNameAsync("accountant") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("accountant"));
            }

            if (await userManager.FindByNameAsync(directorEmail) == null)
            {
                User director = new User { Email = directorEmail, UserName = directorEmail };
                IdentityResult result = await userManager.CreateAsync(director, directorPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(director, "director");
                }
            }

            if (await userManager.FindByNameAsync(storekeeperEmail) == null)
            {
                User storekeeper = new User { Email = storekeeperEmail, UserName = storekeeperEmail };
                IdentityResult result = await userManager.CreateAsync(storekeeper, storekeeperPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(storekeeper, "storekeeper");
                }
            }

            if(await userManager.FindByNameAsync(managerEmail) == null)
            {
                User manager = new User { Email = managerEmail, UserName = managerEmail };
                IdentityResult result = await userManager.CreateAsync(manager, managerPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(manager, "manager");
                }
            }

            if(await userManager.FindByNameAsync(accountantEmail) == null)
            {
                User accountant = new User { Email = accountantEmail, UserName = accountantEmail };
                IdentityResult result = await userManager.CreateAsync(accountant, accountantPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(accountant, "accountant");
                }
            }
        }
    }
}
