using NUnit.Framework;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_HFT_2023241.Logic;
using WD7UVN_HFT_2023241.Repository;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace WD7UVN_HFT_2023241.Test
{
    public class Tests
    {
		Mock<ICRUD> mockCRUD;
		LogicServices logic;

        [SetUp]
        public void Setup()
        {
		    var data = new List<Customer>()
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
			
			mockCRUD = new Mock<ICRUD>();
			mockCRUD.Setup(p => p.ReadAllCustomers()).Returns(data);
			logic = new LogicServices(mockCRUD.Object);
        }

        [Test]
        public void CreateCustomerTest()
        {
			Customer c = new Customer()
			{
				NAME = "Teszt Kft.",
				ID = 3
			};

			logic.CRUDOperations.CreateCustomer(c);

			mockCRUD.Verify(p => p.CreateCustomer(c), Times.Once);
        }
    }
}
