﻿using System;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Repository
{
    public static class Database
    {
        public static CompanyDbContext Context { get; set; }
    }
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

            modelBuilder.Entity<Customer>(customer => customer
                .HasOne<Service>()
                .WithMany()
                .HasForeignKey(customer => customer.SERVICE_ID)
                .OnDelete(DeleteBehavior.Cascade));

            //loading test values
            modelBuilder.Entity<Customer>().HasData(
                new Customer{
                NAME = "Szemed Fénye Optika Kft.",
                ID = 1,
                SERVICE_ID = 1}
            );

            modelBuilder.Entity<Service>().HasData(
                new Service{
                NAME = "Microsoft Exchange",
                ID = 1,
                MAINTAINER = 1}
            );

            modelBuilder.Entity<MaintainerTeam>().HasData(
                new MaintainerTeam{
                ID = 1,
                NAME = "Microsoft Team",
                LEADER_EMPLOYEE_ID = 2}
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee{
                ID = 1,
                NAME = "Gipsz Jakab",
                MANAGER = 2,
                MAINTAINER_ID = 1},
                
                new Employee{
                NAME = "Székely Csaba",
                ID = 3,
                MANAGER = 2,
                MAINTAINER_ID = 1},

                new Employee{
                NAME = "Nagy Krisztina",
                ID = 2,
                MAINTAINER_ID = 1}
            );
        }
    }
}
