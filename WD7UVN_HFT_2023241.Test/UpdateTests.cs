using NUnit.Framework;
using WD7UVN_HFT_2023241.Logic;
using WD7UVN_HFT_2023241.Repository;
using System.Linq;

namespace WD7UVN_HFT_2023241.Test
{
    public class UpdateTests
    {
        LogicServices logic;

        [SetUp]
        public void Setup()
        {
            logic = new LogicServices(new CRUD());
            Database.Context = new CompanyDbContext();
        }

        [Test]
        public void UpdateCustomerTest()
        {
            var testData = logic.CRUDOperations.ReadAllCustomers().ToList()[0];
            testData.NAME = "Updated Customer Name";

            logic.CRUDOperations.UpdateCustomer(testData);

            Assert.That(logic.CRUDOperations.ReadAllCustomers().ToList()[0] == testData);
        }

		[Test]
        public void UpdateEmployeeTest()
        {
            var testData = logic.CRUDOperations.ReadAllEmployees().ToList()[0];
            testData.NAME = "Updated Employee Name";

            logic.CRUDOperations.UpdateEmployee(testData);

            Assert.That(logic.CRUDOperations.ReadAllEmployees().ToList()[0] == testData);
        }

		[Test]
        public void UpdateServiceTest()
        {
            var testData = logic.CRUDOperations.ReadAllServices().ToList()[0];
            testData.NAME = "Updated Service Name";

            logic.CRUDOperations.UpdateService(testData);

            Assert.That(logic.CRUDOperations.ReadAllServices().ToList()[0] == testData);
        }

		[Test]
        public void UpdateMaintainerTeamTest()
        {
            var testData = logic.CRUDOperations.ReadAllMaintainerTeams().ToList()[0];
            testData.NAME = "Updated MaintainerTeam Name";

            logic.CRUDOperations.UpdateMaintainerTeam(testData);

            Assert.That(logic.CRUDOperations.ReadAllMaintainerTeams().ToList()[0] == testData);
        }
    }
}
