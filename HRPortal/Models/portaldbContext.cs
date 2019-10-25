using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class portaldbContext : IdentityDbContext<IdentityUser>
    {
        public portaldbContext(DbContextOptions<portaldbContext> options) : base(options)
        {

        }
        public DbSet<Models.Employee> employees { get; set; }
        public DbSet<Models.Educationdetails> educationdetails { get; set; }
        public DbSet<Models.Employeeskills> employeeskills { get; set; }
        public DbSet<Models.Experiencedetails> experiencedetails { get; set; }



    }
}
