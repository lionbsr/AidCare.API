using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using AidCare.Entities;


namespace AidCare.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BloodGlucose> BloodGlucoses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TC kimlik numarasının benzersiz (unique) olması için
            modelBuilder.Entity<User>()
                .HasIndex(u => u.IdentityNumber)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }



    }
}
