using JobPortal.web.Models;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.web.Data
{
    public class SeedingData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] Roles = { "SUPERADMIN", "ADMIN", "EMPLOYER", "PUBLIC" };

            // Create roles if they don't exist
            foreach (string roleName in Roles)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Seed a super admin user if they don't already exist
            if (await _userManager.FindByNameAsync("superadmin@gmail.com") == null)
            {
                var superAdminRole = await _roleManager.FindByNameAsync("SUPERADMIN");
                var user = new ApplicationUser
                {
                    FirstName = "Super",
                    LastName = "Admin",
                    IsActive = true,
                    UserRoleId = superAdminRole.Id,
                    UserName = "superadmin@gmail.com",
                    Email = "superadmin@gmail.com",
                    PhoneNumber = "1122334455",
                    Address = "Bhaktapur",
                    CreatedBy = "superadmin",
                    CreatedDate = DateTime.Now,
                };

                // Create the user and assign them the SUPERADMIN role
                var res = await _userManager.CreateAsync(user, "Super@dmin1");
                await _userManager.SetLockoutEnabledAsync(user, false);
                if (res.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "SUPERADMIN");
                }
            }
        }
    }
}
