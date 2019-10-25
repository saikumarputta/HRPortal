using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRPortal.Models
{
    public partial class PortaldbContext : IdentityDbContext<IdentityUser>
    {
        public PortaldbContext()
        {
        }

        public PortaldbContext(DbContextOptions<PortaldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Educationdetails> Educationdetails { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Employeeskills> Employeeskills { get; set; }
        public virtual DbSet<Experiencedetails> Experiencedetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new {Id = "1",Name ="Admin",NoramlizedName = "ADMIN"  },
                new {Id = "2",Name = "Employees",NormalizedName = "EMPLOYEE" }
                );
            modelBuilder.Entity<Educationdetails>(entity =>
            {
                entity.ToTable("educationdetails", "portaldb");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("fk_EducationDetails_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Comments)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.InstituteUniversity)
                    .IsRequired()
                    .HasColumnName("Institute/University")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.YearOfPass)
                    .HasColumnName("yearOfPass")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Educationdetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_EducationDetails");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee", "portaldb");

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.OfficePhoneNumber)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.WebUrl)
                    .HasColumnName("WebURL")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employeeskills>(entity =>
            {
                entity.ToTable("employeeskills", "portaldb");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("fk_EmployeeSkills_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Comments)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.EmployeeSkill)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SkillRating).HasColumnType("int(11)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Employeeskills)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_EmployeeSkills");
            });

            modelBuilder.Entity<Experiencedetails>(entity =>
            {
                entity.ToTable("experiencedetails", "portaldb");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("fk_ExperienceDetails_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.EndYear).HasColumnType("date");

                entity.Property(e => e.StartYear).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Experiencedetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_ExperienceDetails");
            });
        }
    }
}
