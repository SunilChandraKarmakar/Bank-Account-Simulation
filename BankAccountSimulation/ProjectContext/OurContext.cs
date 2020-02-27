using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel;
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<Account> Accounts { get; set; }

        [Obsolete]
        public DbQuery<CustomerNotInAccount> CustomerNotInAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source = DESKTOP-HHA0TOP; 
                                        Initial Catalog = BankAccountSimulation; 
                                        Integrated Security = True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasIndex(a=> new { a.UserName, a.Email, a.ContactNo}).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c=> c.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c=> c.Name).IsUnique();
            modelBuilder.Entity<Branch>().HasIndex(b=> new { b.Name, b.Email}).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c=> new { c.Email, c.ContactNo}).IsUnique();
            modelBuilder.Entity<AccountType>().HasIndex(a=>a.Name).IsUnique();
            modelBuilder.Entity<AccountStatus>().HasIndex(a=>a.Name).IsUnique();
            modelBuilder.Entity<Account>().HasIndex(a=> new { a.AccountNumber }).IsUnique();
            modelBuilder.Query<CustomerNotInAccount>().ToView("CustomerNotInAccount"); 

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
