using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Homesick.Models;

namespace Homesick.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Food>().ToTable("Food");
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Chef>().ToTable("Chef");
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Chef> Chefs { get; set; }
    }
}
