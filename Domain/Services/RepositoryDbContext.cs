using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TradingPlatform.Domain.Entities;

namespace TradingPlatform.Domain.Services
{
    public class RepositoryDbContext : IdentityDbContext<ApplicationUser>
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options): base(options)
        {
          
        }

        public override DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductImageThumbnail> ProductImageThumbNails { get; set; }
    }
}
