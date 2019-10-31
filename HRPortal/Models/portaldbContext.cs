using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRPortal.Models
{
    public partial class portaldbContext : DbContext
    {
        public portaldbContext()
        {
        }

        public portaldbContext(DbContextOptions<portaldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Educationdetails> Educationdetails { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Employeeskills> Employeeskills { get; set; }
        public virtual DbSet<Experiencedetails> Experiencedetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=portaldb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Educationdetails>(entity =>
            {
                entity.ToTable("educationdetails", "portaldb");

                entity.HasIndex(e => e.EmployeeId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.Education)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.InstituteUniversity)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.YearOfPass).HasColumnType("int(11)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Educationdetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_educationdetails_employees_EmployeeId");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee", "portaldb");

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.OfficePhoneNumber).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.Photo).IsUnicode(false);

                entity.Property(e => e.WebUrl).IsUnicode(false);
            });

            modelBuilder.Entity<Employeeskills>(entity =>
            {
                entity.ToTable("employeeskills", "portaldb");

                entity.HasIndex(e => e.EmployeeId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.EmployeeSkill)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SkillRating).HasColumnType("int(11)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Employeeskills)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_employeeskills_employees_EmployeeId");
            });

            modelBuilder.Entity<Experiencedetails>(entity =>
            {
                entity.ToTable("experiencedetails", "portaldb");

                entity.HasIndex(e => e.EmployeeId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Experiencedetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_experiencedetails_employees_EmployeeId");
            });
        }
    }
}
