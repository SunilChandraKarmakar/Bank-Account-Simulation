using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectContext
{
    public class OurContext : DbContext 
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source = DESKTOP-HHA0TOP; 
                                        Initial Catalog = BankAccountSimulation; 
                                        Integrated Security = True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasIndex(a=> new { a.UserName, a.Email, a.ContactNo}).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c=> c.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c=> c.Name).IsUnique();
            modelBuilder.Entity<Branch>().HasIndex(b=> new { b.Name, b.Email}).IsUnique();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
