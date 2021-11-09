using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.Domain.Entities;

namespace TradingPlatform.Persistence.Database
{
    public static class DbInitialiser
    {
        public static void Seed(this IServiceProvider serviceProvider)
        {

            using (RepositoryDbContext context = serviceProvider.GetRequiredService<RepositoryDbContext>())
            {
                var user = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@Gmail.COM",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    //PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    user.PasswordHash = password.HashPassword(user, "Admin1");
                    context.Add(user);
                    context.SaveChanges();
                }
                if (!context.Roles.Any())
                {
                    var roles = new IdentityRole[]
                    {
                    new IdentityRole("Admin"),
                     new IdentityRole("Seller"),
                      new IdentityRole("Buyer"),
                       new IdentityRole("Editor"),
                        new IdentityRole("Manager"),

                    };
                    context.Roles.AddRange(roles);
                    context.SaveChanges();
                }
                if (!context.UserRoles.Any())
                {

                    var role = context.Roles.Where(item => item.Name == "Admin").FirstOrDefault();
                    var userAdmin = context.Users.Where(item => item.UserName == "Admin").FirstOrDefault();
                    if (role != null && userAdmin != null)
                        context.UserRoles.Add(new IdentityUserRole<string>() { RoleId = role.Id, UserId = userAdmin.Id });
                }
                Dictionary<string, Category> categories = new();
                if (!context.Categories.Any())
                {
                    var genresList = new Category[]
                        {
                       new Category ("Screens",  "All kinds of screens" ),
                       new Category ("PC","Pre-builded personal computers "),
                       new Category ("PC parts", "Personal computer parts and accesories"),
                       new Category ("Mikes", "Device that allows you to speak"),
                       new Category ("Headphones", "Device that allows you to hear"),
                        };
                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.Name, genre);
                    }
                    context.Categories.AddRange(categories.Select(c => c.Value));
                }
                if (!context.Products.Any())
                {
                    context.AddRange(
                       new Product("Intel core i3", "4 core processor", 2500, 50, categories["PC parts"]),
                       new Product("Intel core i5", "2 core processor", 5000, 100, categories["PC parts"]),
                       new Product("Intel core i7", "8 core processor", 7500, 150, categories["PC parts"]),
                       new Product("Amd ryzen 3", "8 core processor", 3000, 75, categories["PC parts"]),
                       new Product("Amd ryzen 5", "8 core processor", 6000, 125, categories["PC parts"]),
                       new Product("Amd ryzen 7", "8 core processor", 9000, 175, categories["PC parts"]),
                              new Product("Intel core i3", "4 core processor", 2500, 50, categories["PC parts"]),
                       new Product("Intel core i5", "2 core processor", 5000, 100, categories["PC parts"]),
                       new Product("Intel core i7", "8 core processor", 7500, 150, categories["PC parts"]),
                       new Product("Amd ryzen 3", "8 core processor", 3000, 75, categories["PC parts"]),
                       new Product("Amd ryzen 5", "8 core processor", 6000, 125, categories["PC parts"]),
                       new Product("Amd ryzen 7", "8 core processor", 9000, 175, categories["PC parts"]),
                              new Product("Intel core i3", "4 core processor", 2500, 50, categories["PC parts"]),
                       new Product("Intel core i5", "2 core processor", 5000, 100, categories["PC parts"]),
                       new Product("Intel core i7", "8 core processor", 7500, 150, categories["PC parts"]),
                       new Product("Amd ryzen 3", "8 core processor", 3000, 75, categories["PC parts"]),
                       new Product("Amd ryzen 5", "8 core processor", 6000, 125, categories["PC parts"]),
                       new Product("Amd ryzen 7", "8 core processor", 9000, 175, categories["PC parts"]),
                              new Product("Intel core i3", "4 core processor", 2500, 50, categories["PC parts"]),
                       new Product("Intel core i5", "2 core processor", 5000, 100, categories["PC parts"]),
                       new Product("Intel core i7", "8 core processor", 7500, 150, categories["PC parts"]),
                       new Product("Amd ryzen 3", "8 core processor", 3000, 75, categories["PC parts"]),
                       new Product("Amd ryzen 5", "8 core processor", 6000, 125, categories["PC parts"]),
                       new Product("Amd ryzen 7", "8 core processor", 9000, 175, categories["PC parts"])
                   );
                    context.SaveChanges();
                }
            }
        }
    }
}
