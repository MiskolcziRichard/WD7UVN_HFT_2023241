using NUnit.Framework;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_HFT_2023241.Logic;
using WD7UVN_HFT_2023241.Repository;
using System.Collections.Generic;
using System.Linq;

namespace WD7UVN_HFT_2023241.Test
{
    public class CreateTests
    {
        LogicServices logic;

        [SetUp]
        public void Setup()
        {
            logic = new LogicServices(new CRUD());
            Database.Context = new CompanyDbContext();
        }

        [Test]
        public void CreateCustomerTest()
        {
            var testData = logic.CRUDOperations.ReadAllCustomers();
            List<Customer> tmp = new List<Customer>(testData);
            Customer s = new Customer()
            {
                ID = 10,
                NAME = "Testing Hungary Kft."
            };
            tmp.Add(s);
            testData.Concat(tmp.AsQueryable());

            logic.CRUDOperations.CreateCustomer(s);

            Assert.That(logic.CRUDOperations.ReadAllCustomers() == testData);
        }

		[Test]
        public void CreateEmployeeTest()
        {
            var testData = logic.CRUDOperations.ReadAllEmployees();
            List<Employee> tmp = new List<Employee>(testData);
            Employee s = new Employee()
            {
                ID = 10,
                NAME = "Teszt Vilmos"
            };
            tmp.Add(s);
            testData.Concat(tmp.AsQueryable());

            logic.CRUDOperations.CreateEmployee(s);

            Assert.That(logic.CRUDOperations.ReadAllEmployees() == testData);
        }

		[Test]
        public void CreateServiceTest()
        {
            var testData = logic.CRUDOperations.ReadAllServices();
            List<Service> tmp = new List<Service>(testData);
            Service s = new Service()
            {
                ID = 10,
                NAME = "System testing"
            };
            tmp.Add(s);
            testData.Concat(tmp.AsQueryable());

            logic.CRUDOperations.CreateService(s);

            Assert.That(logic.CRUDOperations.ReadAllServices() == testData);
        }

		[Test]
        public void CreateMaintainerTeamTest()
        {
            var testData = logic.CRUDOperations.ReadAllMaintainerTeams();
            List<MaintainerTeam> tmp = new List<MaintainerTeam>(testData);
            MaintainerTeam s = new MaintainerTeam()
            {
                ID = 10,
                NAME = "Tesztelő csapat"
            };
            tmp.Add(s);
            testData.Concat(tmp.AsQueryable());

            logic.CRUDOperations.CreateMaintainerTeam(s);

            Assert.That(logic.CRUDOperations.ReadAllMaintainerTeams() == testData);
        }
    }
}
