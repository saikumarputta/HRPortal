using HRPortal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class portaldbContext : IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public portaldbContext(DbContextOptions<portaldbContext> options) : base(options)
        {

        }
        public DbSet<Models.Employee> employees { get; set; }
        public DbSet<Models.Educationdetails> educationdetails { get; set; }
        public DbSet<Models.Employeeskills> employeeskills { get; set; }
        public DbSet<Models.Experiencedetails> experiencedetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>().Property(x => x.LockoutEnabled).HasConversion(new BoolToZeroOneConverter<Int32>());
            builder.Entity<IdentityUser>().Property(x => x.EmailConfirmed).HasConversion(new BoolToZeroOneConverter<Int32>());
            builder.Entity<IdentityUser>().Property(x => x.PhoneNumberConfirmed).HasConversion(new BoolToZeroOneConverter<Int32>());
            builder.Entity<IdentityUser>().Property(x => x.TwoFactorEnabled).HasConversion(new BoolToZeroOneConverter<Int32>());

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Employee", NormalizedName = "EMPLOYEE" }
                );
        }
    }
   
}
