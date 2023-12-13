using System;
using WD7UVN_HFT_2023241.Models;
using System.Collections.Generic;

namespace WD7UVN_HFT_2023241.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService();

            Console.WriteLine("All employees:\n");
            List<Employee> employeeList = rest.Get<Employee>("/api/Employee/");
			foreach (Employee e in employeeList)
			{
				Console.WriteLine(
					e.NAME +
					": " +
					e.ID
				);
			}

            Console.WriteLine("\n\nAll customers:\n");
            List<Customer> customerList = rest.Get<Customer>("/api/Customer/");
			foreach (Customer c in customerList)
			{
				Console.WriteLine(
					c.NAME +
					": " +
					c.ID
				);
			}

            Console.WriteLine("\n\nMaintainer teams:\n");
            List<MaintainerTeam> maintainerTeamList = rest.Get<MaintainerTeam>("/api/MaintainerTeam/");
			foreach (MaintainerTeam m in maintainerTeamList)
			{
				Console.WriteLine(
					m.NAME + 
					": " +
					m.ID
				);
			}

            Console.WriteLine("\n\nMaintained services:\n");
            List<Service> serviceList = rest.Get<Service>("/api/Service/");
			foreach (Service s in serviceList)
			{
				Console.WriteLine(
					s.NAME +
					": " +
					s.ID +
					" -> " +
					s.IP
					+ ":" +
					s.PORT
				);
			}
        }
    }
}
