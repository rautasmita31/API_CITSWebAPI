using System;
using Microsoft.EntityFrameworkCore;
using API_CITSWebAPI.Entities;


namespace API_CITSWebAPI.DAL
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<CompanyDetails> CompanyDetail { get; set; }
        public DbSet<EmployeeManagement> EmployeeManagements { get; set; }
        public DbSet<AttendanceManagement> AttendanceManagements { get; set; }
      

        public CompanyDbContext() : base()
        {

        }
        public CompanyDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeManagement>()
                .HasOne(e => e.CompanyDetails)
                .WithMany(d => d.EmployeeManagements)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AttendanceManagement>()
               .HasOne(a => a.EmployeeManagement)
               .WithMany(e => e.AttendanceManagement)
               .OnDelete(DeleteBehavior.Cascade);     

        }
    }
    }


