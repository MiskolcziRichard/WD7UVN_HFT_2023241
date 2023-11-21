using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Repository
{
    public class CompanyDbContext : DbContext
    {
        //Tables
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MaintainerTeam> Maintainers { get; set; }
        public DbSet<Service> Services { get; set; }

        public CompanyDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                        .UseInMemoryDatabase("company");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
