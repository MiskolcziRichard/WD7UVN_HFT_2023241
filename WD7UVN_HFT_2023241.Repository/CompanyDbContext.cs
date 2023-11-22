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

                //loading test values
                Customers.Add(new Customer{
                    NAME = "Szemed Fénye Optika Kft.",
                    ID = 1,
                    SERVICE_ID = 1
                });

                Services.Add(new Service{
                    NAME = "Microsoft Exchange",
                    ID = 1,
                    MAINTAINER = 1,
                });

                Maintainers.Add(new MaintainerTeam{
                    ID = 1,
                    NAME = "Microsoft Team",
                    LEADER_EMPLOYEE_ID = 2
                });

                Employees.Add(new Employee{
                    ID = 1,
                    NAME = "Gipsz Jakab",
                    MANAGER = 2,
                    MAINTAINER_ID = 1
                });

                Employees.Add(new Employee{
                    NAME = "Székely Csaba",
                    ID = 3,
                    MANAGER = 2,
                    MAINTAINER_ID = 1
                });

                Employees.Add(new Employee{
                    NAME = "Nagy Krisztina",
                    ID = 2,
                    MAINTAINER_ID = 1
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
