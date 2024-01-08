using System;
using System.Linq;
using System.Collections.Generic;
using ConsoleTools;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Client
{
    public class NonCRUD 
    {
        private static void RESTWhoMaintainsService(int id)
        {
            var res = RestService.WhoMaintainsService(id);
            if (res != null)
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
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void WhoMaintainsService()
        {
            var menu = new ConsoleMenu();
            foreach (Service s in RestService.Get<Service>("/api/Service"))
            {
                menu.Add($"{s.NAME}: {s.ID}", () => RESTWhoMaintainsService(s.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RESTWhoUsesService(int id)
        {
            var res = RestService.WhoUsesService(id);
            if (res != null)
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
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void WhoUsesService()
        {
            var menu = new ConsoleMenu();
            foreach (Service s in RestService.Get<Service>("/api/Service"))
            {
                menu.Add($"{s.NAME}: {s.ID}", () => RESTWhoUsesService(s.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RESTWhoIsResponsibleForService(int id)
        {
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
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void WhoIsResponsibleForService()
        {
            var menu = new ConsoleMenu();
            foreach (Service s in RestService.Get<Service>("/api/Service"))
            {
                menu.Add($"{s.NAME}: {s.ID}", () => RESTWhoIsResponsibleForService(s.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RESTGetSubordinates(int id)
        {
            var res = RestService.GetSubordinates(id);
            if (res != null)
            {
                foreach (Employee e in res)
                {
                    Console.WriteLine("Name: " + e.NAME);
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
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void GetSubordinates()
        {
            var menu = new ConsoleMenu();
            foreach (Employee e in RestService.Get<Employee>("/api/Employee"))
            {
                menu.Add($"{e.NAME}: {e.ID}", () => RESTGetSubordinates(e.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RESTWhoWorksInMaintainerTeam(int id)
        {
            var res = RestService.WhoWorksInMaintainerTeam(id);
            if (res != null)
            {
                foreach (Employee e in res)
                {
                    Console.WriteLine("Name: " + e.NAME);
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
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void WhoWorksInMaintainerTeam()
        {
            var menu = new ConsoleMenu();
            foreach(MaintainerTeam m in RestService.Get<MaintainerTeam>("/api/MaintainerTeam"))
            {
                Console.WriteLine("Team name: " + m.NAME);
                Console.WriteLine("ID: " + m.ID + "\n\n");
                menu.Add($"{m.NAME}: {m.ID}", () => RESTWhoWorksInMaintainerTeam(m.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
