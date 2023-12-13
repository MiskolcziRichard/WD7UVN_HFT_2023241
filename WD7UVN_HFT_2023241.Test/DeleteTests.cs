using NUnit.Framework;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_HFT_2023241.Logic;
using WD7UVN_HFT_2023241.Repository;
using System.Collections.Generic;
using System.Linq;

namespace WD7UVN_HFT_2023241.Test
{
    public class DeleteTests
    {
        LogicServices logic;

        [SetUp]
        public void Setup()
        {
            logic = new LogicServices(new CRUD());
            Database.Context = new CompanyDbContext();
        }

        [Test]
        public void DeleteCustomerTest()
        {
            var tmp = logic.CRUDOperations.ReadAllCustomers();
            List<Customer> testData = new List<Customer>(tmp);
            testData.Remove(testData[0]);

            logic.CRUDOperations.DeleteCustomer(logic.CRUDOperations.ReadAllCustomers().ToList()[0].ID);

            Assert.That(logic.CRUDOperations.ReadAllCustomers().ToList().SequenceEqual(testData));
        }

		[Test]
        public void DeleteEmployeeTest()
        {
            var tmp = logic.CRUDOperations.ReadAllEmployees();
            List<Employee> testData = new List<Employee>(tmp);
            testData.Remove(testData[0]);

            logic.CRUDOperations.DeleteEmployee(logic.CRUDOperations.ReadAllEmployees().ToList()[0].ID);

            Assert.That(logic.CRUDOperations.ReadAllEmployees().ToList().SequenceEqual(testData));
        }

		[Test]
        public void DeleteServiceTest()
        {
            var tmp = logic.CRUDOperations.ReadAllServices();
            List<Service> testData = new List<Service>(tmp);
            testData.Remove(testData[0]);

            logic.CRUDOperations.DeleteService(logic.CRUDOperations.ReadAllServices().ToList()[0].ID);

            Assert.That(logic.CRUDOperations.ReadAllServices().ToList().SequenceEqual(testData));
        }

		[Test]
        public void DeleteMaintainerTeamTest()
        {
            var tmp = logic.CRUDOperations.ReadAllMaintainerTeams();
            List<MaintainerTeam> testData = new List<MaintainerTeam>(tmp);
            testData.Remove(testData[0]);

            logic.CRUDOperations.DeleteMaintainerTeam(logic.CRUDOperations.ReadAllMaintainerTeams().ToList()[0].ID);

            Assert.That(logic.CRUDOperations.ReadAllMaintainerTeams().ToList().SequenceEqual(testData));
        }
    }
}
