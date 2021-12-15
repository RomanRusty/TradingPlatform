using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.DatabaseService.Persistence.Database
{
    public static class DbInitialiser
    {
        public static async void Seed(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using (var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>())
            {
                if (!roleManger.Roles.Any())
                {
                    await roleManger.CreateAsync(new IdentityRole() { Name = "Admin" });
                    await roleManger.CreateAsync(new IdentityRole() { Name = "Seller" });
                    await roleManger.CreateAsync(new IdentityRole() { Name = "Custumer" });
                }
            }
            using (var userManger = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>())
            {
                if (!userManger.Users.Any())
                {
                    var admin = new ApplicationUser
                    {
                        Email = "admin@gmail.com",
                        UserName = "admin@gmail.com",
                        //PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };
                    await userManger.CreateAsync(admin, "Admin1");

                    await userManger.AddToRoleAsync(admin, "Admin");

                    var seller = new ApplicationUser
                    {
                        Email = "seller@gmail.com",
                        UserName = "seller@gmail.com",
                        //PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };
                    await userManger.CreateAsync(seller, "Seller1");

                    await userManger.AddToRoleAsync(seller, "Seller");

                    var custumer = new ApplicationUser
                    {
                        Email = "custumer@gmail.com",
                        UserName = "custumer@gmail.com",
                        //PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };
                    await userManger.CreateAsync(custumer, "Custumer1");

                    await userManger.AddToRoleAsync(custumer, "Custumer");
                }
            }
            using RepositoryDbContext context = scope.ServiceProvider.GetRequiredService<RepositoryDbContext>();

            if (!context.Categories.Any())
            {
                await context.Categories.AddRangeAsync(new Category[]
                    {
                       new Category ("Screens",  "All kinds of screens" ),
                       new Category ("PC","Pre-builded personal computers "),
                       new Category ("PC parts", "Personal computer parts and accesories"),
                       new Category ("Mikes", "Device that allows you to speak"),
                       new Category ("Headphones", "Device that allows you to hear"),
                    });
               await context.SaveChangesAsync();
            }
            if (!context.Products.Any())
            {
                Dictionary<string, Category> categories = new();
                foreach (var category in context.Categories)
                {
                    categories.Add(category.Name, category);
                }
                List<Product> products = new()
                {
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
                };
                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
                List<ProductImageThumbnail> imageThumbnails = new();

                IHostingEnvironment env = scope.ServiceProvider.GetRequiredService<IHostingEnvironment>();
                string path = env.ContentRootPath + "\\Database\\MockImages\\Thumbnails\\";
                path = path.Replace("WebApi", "Persistence");
                string imgExt = ".jpg";
                int index = 1;
                for (int i = 0; i < products.Count; i++)
                {
                    string endPath = path + (index++) + imgExt;

                    if (File.Exists(endPath))
                    {
                        imageThumbnails.Add(new ProductImageThumbnail()
                        {
                            Product = products[i],
                            Data = await File.ReadAllBytesAsync(endPath),
                            Name = products[i].Name,
                        });
                    }
                    else
                    {
                        index = 1;
                        i--;
                    }

                }
                await context.ProductImageThumbNails.AddRangeAsync(imageThumbnails);

                index = 1;
                List<ProductImage> productImages = new();
                for (int i = 0; i < products.Count; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        string endPath = path + (index++) + imgExt;

                        if (File.Exists(endPath))
                        {
                            productImages.Add(new ProductImage()
                            {
                                Product = products[i],
                                Data = await File.ReadAllBytesAsync(endPath),
                                Name = products[i].Name,
                            });
                        }
                        else
                        {
                            index = 1;
                            i--;
                        }
                    }
                }
                await context.ProductImages.AddRangeAsync(productImages);
                await context.SaveChangesAsync();
            }
        }
    }
}
