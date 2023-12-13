using NUnit.Framework;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_HFT_2023241.Logic;
using WD7UVN_HFT_2023241.Repository;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace WD7UVN_HFT_2023241.Test
{
    public class ReadAllTests
    {
        LogicServices logic;
		Mock<ICRUD> mockCRUD;

        [SetUp]
        public void Setup()
        {
			var customerData = new List<Customer>()
			{
				new Customer
				{
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
			}.AsQueryable();
			
            var maintainerTeamData = new List<MaintainerTeam>()
            {
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
            }.AsQueryable();
			
            var serviceData = new List<Service>()
            {
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
            }.AsQueryable();
			
            var employeeData = new List<Employee>()
            {
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
            }.AsQueryable();
			
            mockCRUD = new Mock<ICRUD>();
			
			mockCRUD.Setup(p => p.ReadAllCustomers()).Returns(customerData);
            mockCRUD.Setup(p => p.ReadAllEmployees()).Returns(employeeData);
            mockCRUD.Setup(p => p.ReadAllServices()).Returns(serviceData);
            mockCRUD.Setup(p => p.ReadAllMaintainerTeams()).Returns(maintainerTeamData);

            logic = new LogicServices(mockCRUD.Object);
        }

        [Test]
        public void ReadCustomerTest()
        {
            var testData = logic.CRUDOperations.ReadAllCustomers().ToList();

            var actualData = logic.CRUDOperations.ReadAllCustomers().ToList();

            Assert.That(actualData.SequenceEqual(testData));
        }

		[Test]
        public void ReadEmployeeTest()
        {
            var testData = logic.CRUDOperations.ReadAllServices().ToList();

            var actualData = logic.CRUDOperations.ReadAllServices().ToList();

            Assert.That(actualData.SequenceEqual(testData));
        }

		[Test]
        public void ReadServiceTest()
        {
            var testData = logic.CRUDOperations.ReadAllServices().ToList();

            var actualData = logic.CRUDOperations.ReadAllServices().ToList();

            Assert.That(actualData.SequenceEqual(testData));
        }

		[Test]
        public void ReadMaintainerTeamTest()
        {
            var testData = logic.CRUDOperations.ReadAllMaintainerTeams().ToList();

            var actualData = logic.CRUDOperations.ReadAllMaintainerTeams().ToList();

            Assert.That(actualData.SequenceEqual(testData));
        }
    }
}
