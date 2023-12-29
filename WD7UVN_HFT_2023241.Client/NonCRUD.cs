using System;
using System.Linq;
using System.Runtime.Serialization;
using ConsoleTools;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Client
{
    public class NonCRUD 
    {
        private static void RESTWhoMaintainsService(int id)
        {
            IQueryable<Employee> res = RestService.WhoMaintainsService(id);
            if (res.Count() != 0)
            {
                foreach (Employee e in res)
                {
                    Console.WriteLine("Név: " + e.NAME);
                    Console.WriteLine("ID: " + e.ID);
                    Console.WriteLine("Email: " + e.EMAIL);
                    Console.WriteLine("Phone: " + e.PHONE);
                    Console.WriteLine("Manager's ID: " + e.MANAGER_ID);
                }
            }
            else
            {
                Console.WriteLine("ERROR: No such database entry was found :/");
            }
        }

        public static void WhoMaintainsService()
        {
            var servicesMenu = new ConsoleMenu();
            foreach (Service s in RestService.Get<Service>("/api/Service"))
            {
                servicesMenu.Add($"{s.NAME}: {s.ID}", () => RESTWhoMaintainsService(s.ID));
            }
        }

        public static void WhoUsesService()
        {
            foreach (Service s in RestService.Get<Service>("/api/Service"))
            {
                Console.WriteLine("Service: " + s.NAME);
                Console.WriteLine("ID: " + s.ID);
            }

            int id = 1;
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.Write("Your choice: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    flag = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number");
                }
            }

            IQueryable<Customer> res = RestService.WhoUsesService(id);
            if (res.Count() != 0)
            {
                foreach (Customer c in res)
                {
                    Console.WriteLine("Name: " + c.NAME);
                    Console.WriteLine("ID: " + c.ID);
                    Console.WriteLine("Email: " + c.EMAIL);
                    Console.WriteLine("Phone: " + c.PHONE);
                }
            }
            else
            {
                Console.WriteLine("No such database entry was found :/");
            }
        }

        public static void WhoIsResponsibleForService()
        {
            foreach (Service s in RestService.Get<Service>("/api/Service"))
            {
                Console.WriteLine("Service: " + s.NAME);
                Console.WriteLine("ID: " + s.ID);
            }

            int id = 1;
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.Write("Your choice: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    flag = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number");
                }
            }

            Employee? res = RestService.WhoIsResponsibleForService(id);
            if (res != null)
            {
                Console.WriteLine("Name: " + res.NAME);
                Console.WriteLine("ID: " + res.ID);
                Console.WriteLine("Email: " + res.EMAIL);
                Console.WriteLine("Phone: " + res.PHONE);
                Console.WriteLine("Maintainer team ID: " + res.MAINTAINER_ID);
            }
            else
            {
                Console.WriteLine("No such database entry was found :/");
            }
        }

        public static void GetSubordinates()
        {
            foreach (Employee e in RestService.Get<Employee>("/api/Employee"))
            {
                Console.WriteLine("Name: " + e.NAME);
                Console.WriteLine("ID: " + e.ID);
            }

            int id = 1;
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.Write("Your choice: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    flag = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number");
                }
            }

            IQueryable<Employee> res = RestService.GetSubordinates(id);
            if (res.Count() != 0)
            {
                foreach (Employee e in res)
                {
                    Console.WriteLine("Név: " + e.NAME);
                    Console.WriteLine("ID: " + e.ID);
                    Console.WriteLine("Email: " + e.EMAIL);
                    Console.WriteLine("Phone: " + e.PHONE);
                    Console.WriteLine("Maintainer team ID: " + e.MAINTAINER_ID);
                }
            }
            else
            {
                Console.WriteLine("No such database entry was found :/");
            }
        }

        public static void WhoWorksInMaintainerTeam()
        {
            foreach(MaintainerTeam m in RestService.Get<MaintainerTeam>("/api/MaintainerTeam"))
            {
                Console.WriteLine("Team name: " + m.NAME);
                Console.WriteLine("ID: " + m.ID + "\n\n");
            }

            int id = 1;
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.Write("Your choice: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    flag = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number");
                }
            }

            IQueryable<Employee> res = RestService.WhoWorksInMaintainerTeam(id);
            if (res.Count() != 0)
            {
                foreach (Employee e in RestService.WhoWorksInMaintainerTeam(id))
                {
                    Console.WriteLine("Név: " + e.NAME);
                    Console.WriteLine("ID: " + e.ID);
                    Console.WriteLine("Email: " + e.EMAIL);
                    Console.WriteLine("Phone: " + e.PHONE);
                    Console.WriteLine("Manager's ID: " + e.MANAGER_ID);
                }
            }
            else
            {
                Console.WriteLine("No such database entry was found :/");
            }
        }
    }
}