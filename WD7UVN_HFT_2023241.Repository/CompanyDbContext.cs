using System;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Repository
{
    public static class Database
    {
        public static CompanyDbContext Context = new CompanyDbContext();
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

            modelBuilder.Entity<Service>(service => service
                .HasOne<MaintainerTeam>()
                .WithMany()
                .HasForeignKey(service => service.MAINTAINER_ID)
                .OnDelete(DeleteBehavior.SetNull));

            modelBuilder.Entity<MaintainerTeam>(team => team
                .HasOne<Employee>()
                .WithMany()
                .HasForeignKey(team => team.LEADER_ID)
                .OnDelete(DeleteBehavior.SetNull));

            modelBuilder.Entity<Employee>(emp => emp
                .HasOne<Employee>()
                .WithMany()
                .HasForeignKey(emp => emp.MANAGER_ID)
                .OnDelete(DeleteBehavior.SetNull));

            //loading test values
            modelBuilder.Entity<Customer>().HasData(
                new Customer{
					NAME = "Szemed Fénye Optika Kft.",
					ID = 1,
					EMAIL = "info@szemedfenye.hu",
					PHONE = "+36 30 123 4567",
					SERVICE_ID = 1
				},
				
				new Customer{
					NAME = "DoBox Logisztika Kft.",
					ID = 2,
					EMAIL = "info@dobox.hu",
					PHONE = "+36 50 234 5678",
					SERVICE_ID = 2
				}
            );

            modelBuilder.Entity<Service>().HasData(
                new Service{
					NAME = "Microsoft Exchange",
					ID = 1,
					ACCOUNT = "admin:password123",
					NOTES = "Currently migrating to EXOnline",
					SERVICE_DOMAIN = "admin.exchange.intranet.szemedfenye.hu",
					PORT = 443,
					IP = "10.42.567.3",
					MAINTAINER_ID = 1
				},
				
				new Service{
					NAME = "OpenLDAP",
					ID = 2,
					ACCOUNT = "ldapadmin:verystrongpassword",
					NOTES = "OpenLDAP directory access protocol on Linux, over SSL",
					SERVICE_DOMAIN = "conf.ldap.intranet.dobox.hu",
					PORT = 636,
					IP = "66.254.114.41",
					MAINTAINER_ID = 2
				}
            );

            modelBuilder.Entity<MaintainerTeam>().HasData(
                new MaintainerTeam{
					ID = 1,
					NAME = "Microsoft Team",
					EMAIL = "microsoft@ourcompany.hu",
					LEADER_ID = 2
				},
				
				new MaintainerTeam{
					ID = 2,
					NAME = "Linux Team",
					LEADER_ID = 4,
					EMAIL = "linux@ourcompany.hu"
				}
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee{
					ID = 1,
					NAME = "Gipsz Jakab",
					EMAIL = "gipsz.jakab@ourcompany.hu",
					PHONE = "+36 20 345 6789",
					MANAGER_ID = 2,
					MAINTAINER_ID = 1
				},
                
                new Employee{
					NAME = "Nagy Krisztina",
					ID = 2,
					MAINTAINER_ID = 1,
					EMAIL = "nagy.krisztina@ourcompany.hu",
					PHONE = "+36 30 987 6543"
				},

                new Employee{
					NAME = "Székely Csaba",
					ID = 3,
					PHONE = "+36 50 8766 5432",
					EMAIL = "szekely.csaba@ourcompany.hu",
					MANAGER_ID = 2,
					MAINTAINER_ID = 1
				},

				new Employee{
					NAME = "Marik Tamás",
					ID = 4,
					PHONE = "+36 20 345 6780",
					EMAIL = "marik.tamas@ourcompany.hu",
					MAINTAINER_ID = 2,
				},

				new Employee{
					NAME = "Dávid András",
					ID = 5,
					PHONE = "+36 51 865 2876",
					EMAIL = "david.andras@ourcompany.hu",
					MANAGER_ID = 4,
					MAINTAINER_ID = 2
				},

				new Employee{
					NAME = "Steiner Zsófia",
					ID = 6,
					PHONE = "+36 20 756 8635",
					MANAGER_ID = 4,
					MAINTAINER_ID = 2
				}
            );
        }
    }
}
