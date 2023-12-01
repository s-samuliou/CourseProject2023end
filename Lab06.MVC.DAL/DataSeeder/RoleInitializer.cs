using Lab06.MVC.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.DataSeeder
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<StudentEntity> studentManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "Qwerty19_!";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("student") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("student"));
            }
            if (await studentManager.FindByNameAsync(adminEmail) == null)
            {
                StudentEntity admin = new StudentEntity { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await studentManager.CreateAsync(admin, password);

                if (result.Succeeded)
                {
                    await studentManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
