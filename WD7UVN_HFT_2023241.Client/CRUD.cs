using System;
using ConsoleTools;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Client
{
    public class CRUD 
    {
        private enum Models
        {
            Customer,
            Employee,
            Service,
            MaintainerTeam
        }

        private static void MethodChooser(CRUDActions action, Models model)
        {
            switch (model)
            {
                case Models.Customer:
                    switch (action)
                    {
                        case CRUDActions.GetAll:
                            ReadAll.Customer();
                            break;
                        case CRUDActions.GetById:
                            Read.Customer();
                            break;
                        case CRUDActions.Create:
                            Create.Customer();
                            break;
                        case CRUDActions.Update:
                            Update.Customer();
                            break;
                        case CRUDActions.Delete:
                            Delete.Customer();
                            break;
                    }
                    break;
                case Models.Employee:
                    switch (action)
                    {
                        case CRUDActions.GetAll:
                            ReadAll.Employee();
                            break;
                        case CRUDActions.GetById:
                            Read.Employee();
                            break;
                        case CRUDActions.Create:
                            Create.Employee();
                            break;
                        case CRUDActions.Update:
                            Update.Employee();
                            break;
                        case CRUDActions.Delete:
                            Delete.Employee();
                            break;
                    }
                    break;
                case Models.Service:
                    switch (action)
                    {
                        case CRUDActions.GetAll:
                            ReadAll.Service();
                            break;
                        case CRUDActions.GetById:
                            Read.Service();
                            break;
                        case CRUDActions.Create:
                            Create.Service();
                            break;
                        case CRUDActions.Update:
                            Update.Service();
                            break;
                        case CRUDActions.Delete:
                            Delete.Service();
                            break;
                    }
                    break;
                case Models.MaintainerTeam:
                    switch (action)
                    {
                        case CRUDActions.GetAll:
                            ReadAll.MaintainerTeam();
                            break;
                        case CRUDActions.GetById:
                            Read.MaintainerTeam();
                            break;
                        case CRUDActions.Create:
                            Create.MaintainerTeam();
                            break;
                        case CRUDActions.Update:
                            Update.MaintainerTeam();
                            break;
                        case CRUDActions.Delete:
                            Delete.MaintainerTeam();
                            break;
                    }
                    break;
            }

        }

        public static void TypeSelectorMenu(CRUDActions action)
        {
            var menu = new ConsoleMenu();
            menu.Add("Customer", () => MethodChooser(action, Models.Customer));
            menu.Add("Employee", () => MethodChooser(action, Models.Employee));
            menu.Add("Service", () => MethodChooser(action, Models.Service));
            menu.Add("Maintainer team", () => MethodChooser(action, Models.MaintainerTeam));
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

       //generic methods are nice and all, but in this instance they would be a pain to implement as they would neccessitate a lot of reflection
       // public static void Read<T>()
       // {
       //     var menu = new ConsoleMenu();
       //     foreach (T c in RestService.Get<T>("/api/" + typeof(T).Name + "/"))
       //     {
       //         menu.Add($"{c}", () => Console.WriteLine(c));
       //     }
       //     menu.Add("Back", ConsoleMenu.Close);
       //     menu.Show();
       // }
    }

    public class Read
    {
        private static void RESTCustomer(int id)
        {
            Customer res = RestService.Get<Customer>(id, "/api/Customer/");
            if (res != null)
            {
                Console.WriteLine("Name: " + res.NAME);
                Console.WriteLine("ID: " + res.ID);
                Console.WriteLine("Email: " + res.EMAIL);
                Console.WriteLine("Phone: " + res.PHONE);
            }
            else
            {
                Console.WriteLine("No such database entry was found :/");
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void Customer()
        {
            var menu = new ConsoleMenu();
            foreach (Customer c in RestService.Get<Customer>("/api/Customer/"))
            {
                menu.Add($"{c.NAME}: {c.ID}", () => RESTCustomer(c.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RESTEmployee(int id)
        {
            Employee res = RestService.Get<Employee>(id, "/api/Employee/");
            if (res != null)
            {
                Console.WriteLine("Name: " + res.NAME);
                Console.WriteLine("ID: " + res.ID);
                Console.WriteLine("Email: " + res.EMAIL);
                Console.WriteLine("Phone: " + res.PHONE);
                Console.WriteLine("Maintainer team's ID: " + res.MAINTAINER_ID);
                Console.WriteLine("Manager's ID: " + res.MANAGER_ID);
            }
            else
            {
                Console.WriteLine("No such database entry was found :/");
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void Employee()
        {
            var menu = new ConsoleMenu();
            foreach (Employee c in RestService.Get<Employee>("/api/Employee/"))
            {
                menu.Add($"{c.NAME}: {c.ID}", () => RESTEmployee(c.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Add("Exit", () => Environment.Exit(0));
            menu.Show();
        }

        private static void RESTService(int id)
        {
            Service res = RestService.Get<Service>(id, "/api/Service/");
            if (res != null)
            {
                Console.WriteLine("Name: " + res.NAME);
                Console.WriteLine("ID: " + res.ID);
                Console.WriteLine("Account: " + res.ACCOUNT);
                Console.WriteLine("IP: " + res.IP);
                Console.WriteLine("Port: " + res.PORT);
                Console.WriteLine("Notes: " + res.NOTES);
                Console.WriteLine("Service domain: " + res.SERVICE_DOMAIN);
                Console.WriteLine("Version: " + res.VERSION);
                Console.WriteLine("Maintainer team's ID: " + res.MAINTAINER_ID);
            }
            else
            {
                Console.WriteLine("No such database entry was found :/");
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void Service()
        {
            var menu = new ConsoleMenu();
            foreach (Service c in RestService.Get<Service>("/api/Service/"))
            {
                menu.Add($"{c.NAME}: {c.ID}", () => RESTService(c.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }   

        private static void RESTMaintainerTeam(int id)
        {
            MaintainerTeam res = RestService.Get<MaintainerTeam>(id, "/api/MaintainerTeam/");
            if (res != null)
            {
                Console.WriteLine("Name: " + res.NAME);
                Console.WriteLine("ID: " + res.ID);
                Console.WriteLine("Email: " + res.EMAIL);
                Console.WriteLine("Leader's ID: " + res.LEADER_ID);
            }
            else
            {
                Console.WriteLine("No such database entry was found :/");
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void MaintainerTeam()
        {
            var menu = new ConsoleMenu();
            foreach (MaintainerTeam c in RestService.Get<MaintainerTeam>("/api/MaintainerTeam/"))
            {
                menu.Add($"{c.NAME}: {c.ID}", () => RESTMaintainerTeam(c.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        } 
    }

    public class ReadAll
    {
        public static void Customer()
        {
            foreach (Customer c in RestService.Get<Customer>("/api/Customer/"))
            {
                Console.WriteLine("Name: " + c.NAME);
                Console.WriteLine("ID: " + c.ID);
                Console.WriteLine("Email: " + c.EMAIL);
                Console.WriteLine("Phone: " + c.PHONE);
                Console.WriteLine("ID of used service: " + c.SERVICE_ID);
                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public static void Employee()
        {
            foreach (Employee c in RestService.Get<Employee>("/api/Employee/"))
            {
                Console.WriteLine("Name: " + c.NAME);
                Console.WriteLine("ID: " + c.ID);
                Console.WriteLine("Email: " + c.EMAIL);
                Console.WriteLine("Phone: " + c.PHONE);
                Console.WriteLine("Maintainer team's ID: " + c.MAINTAINER_ID);
                Console.WriteLine("Manager's ID: " + c.MANAGER_ID);
                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public static void Service()
        {
            foreach (Service c in RestService.Get<Service>("/api/Service/"))
            {
                Console.WriteLine("Name: " + c.NAME);
                Console.WriteLine("ID: " + c.ID);
                Console.WriteLine("Account: " + c.ACCOUNT);
                Console.WriteLine("IP: " + c.IP);
                Console.WriteLine("Port: " + c.PORT);
                Console.WriteLine("Notes: " + c.NOTES);
                Console.WriteLine("Service domain: " + c.SERVICE_DOMAIN);
                Console.WriteLine("Version: " + c.VERSION);
                Console.WriteLine("Maintainer team's ID: " + c.MAINTAINER_ID);
                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }   

        public static void MaintainerTeam()
        {
            foreach (MaintainerTeam c in RestService.Get<MaintainerTeam>("/api/MaintainerTeam/"))
            {
                Console.WriteLine("Name: " + c.NAME);
                Console.WriteLine("ID: " + c.ID);
                Console.WriteLine("Email: " + c.EMAIL);
                Console.WriteLine("Leader's ID: " + c.LEADER_ID);
                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        } 
    }

    public class Create
    {
        public static void Customer()
        {
            while (true)
            {
                try
                {
                    Console.Write("ID (integer): ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Name (text): ");
                    string name = Console.ReadLine();

                    Console.Write("Email (text): ");
                    string email = Console.ReadLine();

                    Console.Write("Phone (text): ");
                    string phone = Console.ReadLine();

                    Console.Write("ServiceID (integer): ");
                    int service_id = Convert.ToInt32(Console.ReadLine());

                    Customer c = new Customer()
                    {
                        ID = id,
                        NAME = name,
                        EMAIL = email,
                        PHONE = phone,
                        SERVICE_ID = service_id
                    };

                    RestService.Put<Customer>(c, "/api/Customer/");

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format!");
                }
            }
        }

        public static void Employee()
        {

            while (true)
            {
                try
                {
                    Console.Write("ID (integer): ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Name (text): ");
                    string name = Console.ReadLine();

                    Console.Write("Email (text): ");
                    string email = Console.ReadLine();

                    Console.Write("Phone (text): ");
                    string phone = Console.ReadLine();

                    Console.Write("Team ID (integer): ");
                    int maintainer_id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Manager's ID (integer): ");
                    int manager_id = Convert.ToInt32(Console.ReadLine());

                    Employee c = new Employee()
                    {
                        ID = id,
                        NAME = name,
                        EMAIL = email,
                        PHONE = phone,
                        MAINTAINER_ID = maintainer_id,
                        MANAGER_ID = manager_id
                    };

                    RestService.Put<Employee>(c, "/api/Employee/");

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format!");
                }
            }
        }

        public static void Service()
        {

            while (true)
            {
                try
                {
                    Console.Write("ID (integer): ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Name (text): ");
                    string name = Console.ReadLine();

                    Console.Write("Maintainer team's ID (integer): ");
                    int maintainer_id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Version (string): ");
                    string version = Console.ReadLine();

                    Console.Write("IP (text): ");
                    string ip = Console.ReadLine();

                    Console.Write("Port (integer): ");
                    int port = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Service account (text): ");
                    string account = Console.ReadLine();

                    Console.Write("Service domain (text): ");
                    string domain = Console.ReadLine();

                    Console.Write("Note(s) (text): ");
                    string notes = Console.ReadLine();

                    Service c = new Service()
                    {
                        ID = id,
                        NAME = name,
                        MAINTAINER_ID = maintainer_id,
                        PORT = port,
                        IP = ip,
                        SERVICE_DOMAIN = domain,
                        ACCOUNT = account,
                        NOTES = notes,
                        VERSION = version
                    };

                    RestService.Put<Service>(c, "/api/Service/");

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format!");
                }
            }
        }   

        public static void MaintainerTeam()
        {

            while (true)
            {
                try
                {
                    Console.Write("ID (integer): ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Name (text): ");
                    string name = Console.ReadLine();

                    Console.Write("Email (text): ");
                    string email = Console.ReadLine();

                    Console.Write("Leader's ID (integer): ");
                    int leader_id = Convert.ToInt32(Console.ReadLine());

                    MaintainerTeam c = new MaintainerTeam()
                    {
                        ID = id,
                        NAME = name,
                        LEADER_ID = leader_id,
                        EMAIL = email
                    };

                    RestService.Put<MaintainerTeam>(c, "/api/MaintainerTeam/");

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format!");
                }
            }
        } 
    }

    public class Update
    {
        public static void Customer()
        {
            int input;
            while (true)
            {
                try
                {
                    Console.Write("Enter a number for the customer's ID: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number.");
                }
            }

            Customer c = RestService.Get<Customer>(input, "/api/Customer/");

            Console.WriteLine("Name: " + c.NAME);
            Console.WriteLine("Email: " + c.EMAIL);
            Console.WriteLine("Phone: " + c.PHONE);
            Console.WriteLine("ID of used service: " + c.SERVICE_ID);

            Console.WriteLine("Now you can modify these fields, except for the ID.");

            while (true)
            {
                try
                {
                    Console.Write("Name (text): ");
                    string name = Console.ReadLine();

                    Console.Write("Email (text): ");
                    string email = Console.ReadLine();

                    Console.Write("Phone (text): ");
                    string phone = Console.ReadLine();

                    Console.Write("ServiceID (integer): ");
                    int service_id = Convert.ToInt32(Console.ReadLine());

                    c = new Customer()
                    {
                        ID = input,
                        NAME = name,
                        EMAIL = email,
                        PHONE = phone,
                        SERVICE_ID = service_id
                    };

                    RestService.Post<Customer>(c, "/api/Customer/");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format!");
                }
            }
        }

        public static void Employee()
        {

            int input;
            while (true)
            {
                try
                {
                    Console.Write("Enter a number for the employee's ID: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number.");
                }
            }

            Employee c = RestService.Get<Employee>(input, "/api/Employee/");

            Console.WriteLine("Name: " + c.NAME);
            Console.WriteLine("ID: " + c.ID);
            Console.WriteLine("Email: " + c.EMAIL);
            Console.WriteLine("Phone: " + c.PHONE);
            Console.WriteLine("Maintainer team's ID: " + c.MAINTAINER_ID);
            Console.WriteLine("Manager's ID: " + c.MANAGER_ID);

            Console.WriteLine("Now you can modify these fields, except for the ID.");

            while (true)
            {
                try
                {
                    Console.Write("Name (text): ");
                    string name = Console.ReadLine();

                    Console.Write("Email (text): ");
                    string email = Console.ReadLine();

                    Console.Write("Phone (text): ");
                    string phone = Console.ReadLine();

                    Console.Write("Team ID (integer): ");
                    int maintainer_id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Manager's ID (integer): ");
                    int manager_id = Convert.ToInt32(Console.ReadLine());

                    c = new Employee()
                    {
                        ID = input,
                        NAME = name,
                        EMAIL = email,
                        PHONE = phone,
                        MANAGER_ID = manager_id,
                        MAINTAINER_ID = maintainer_id
                    };

                    RestService.Post<Employee>(c, "/api/Employee/");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format!");
                }
            }
        }

        public static void Service()
        {

            int input;
            while (true)
            {
                try
                {
                    Console.Write("Enter a number for the service's ID: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number.");
                }
            }

            Service c = RestService.Get<Service>(input, "/api/Service/");

            Console.WriteLine("Name: " + c.NAME);
            Console.WriteLine("ID: " + c.ID);
            Console.WriteLine("Account: " + c.ACCOUNT);
            Console.WriteLine("IP: " + c.IP);
            Console.WriteLine("Port: " + c.PORT);
            Console.WriteLine("Notes: " + c.NOTES);
            Console.WriteLine("Service domain: " + c.SERVICE_DOMAIN);
            Console.WriteLine("Version: " + c.VERSION);
            Console.WriteLine("Maintainer team's ID: " + c.MAINTAINER_ID);
            Console.WriteLine("Now you can modify these fields, except for the ID.");

            while (true)
            {
                try
                {
                    Console.Write("Name (text): ");
                    string name = Console.ReadLine();

                    Console.Write("Maintainer team's ID (integer): ");
                    int maintainer_id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Version (string): ");
                    string version = Console.ReadLine();

                    Console.Write("IP (text): ");
                    string ip = Console.ReadLine();

                    Console.Write("Port (integer): ");
                    int port = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Service account (text): ");
                    string account = Console.ReadLine();

                    Console.Write("Service domain (text): ");
                    string domain = Console.ReadLine();

                    Console.Write("Note(s) (text): ");
                    string notes = Console.ReadLine();

                    c = new Service()
                    {
                        ID = input,
                        NAME = name,
                        MAINTAINER_ID = maintainer_id,
                        PORT = port,
                        IP = ip,
                        SERVICE_DOMAIN = domain,
                        ACCOUNT = account,
                        NOTES = notes,
                        VERSION = version
                    };

                    RestService.Post<Service>(c, "/api/Service/");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format!");
                }
            }
        }   

        public static void MaintainerTeam()
        {

            int input;
            while (true)
            {
                try
                {
                    Console.Write("Enter a number for the service's ID: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number.");
                }
            }

            MaintainerTeam c = RestService.Get<MaintainerTeam>(input, "/api/MaintainerTeam/");

            Console.WriteLine("Name: " + c.NAME);
            Console.WriteLine("ID: " + c.ID);
            Console.WriteLine("Email: " + c.EMAIL);
            Console.WriteLine("Leader's ID: " + c.LEADER_ID);

            Console.WriteLine("Now you can modify these fields, except for the ID.");

            while (true)
            {
                try
                {
                    Console.Write("Name (text): ");
                    string name = Console.ReadLine();

                    Console.Write("Email (text): ");
                    string email = Console.ReadLine();

                    Console.Write("Leader's ID (integer): ");
                    int leader_id = Convert.ToInt32(Console.ReadLine());

                    c = new MaintainerTeam()
                    {
                        ID = input,
                        NAME = name,
                        LEADER_ID = leader_id,
                        EMAIL = email
                    };

                    RestService.Post<MaintainerTeam>(c, "/api/MaintainerTeam/");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format!");
                }
            }
        } 
    }

    public class Delete
    {
        private static void RESTCustomer(int id)
        {
            try
            {
                RestService.Delete(id, "/api/Customer/");
                Console.WriteLine("Successfully deleted Customer with ID {0}", id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh-oh...");
                Console.WriteLine(e.Message);
            }
        }
        public static void Customer()
        {
            var menu = new ConsoleMenu();
            foreach (Customer c in RestService.Get<Customer>("/api/Customer/"))
            {
                menu.Add($"{c.NAME}: {c.ID}", () => RESTCustomer(c.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RESTEmployee(int id)
        {
            try
            {
                RestService.Delete(id, "/api/Employee/");
                Console.WriteLine("Successfully deleted Employee with ID {0}", id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh-oh...");
                Console.WriteLine(e.Message);
            }
        }
        public static void Employee()
        {
            var menu = new ConsoleMenu();
            foreach (Employee c in RestService.Get<Employee>("/api/Employee/"))
            {
                menu.Add($"{c.NAME}: {c.ID}", () => RESTEmployee(c.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RESTService(int id)
        {
            try
            {
                RestService.Delete(id, "/api/Service/");
                Console.WriteLine("Successfully deleted Service with ID {0}", id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh-oh...");
                Console.WriteLine(e.Message);
            }
        }   
        public static void Service()
        {
            var menu = new ConsoleMenu();
            foreach (Service c in RestService.Get<Service>("/api/Service/"))
            {
                menu.Add($"{c.NAME}: {c.ID}", () => RESTService(c.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        private static void RESTMaintainerTeam(int id)
        {
            try
            {
                RestService.Delete(id, "/api/MaintainerTeam/");
                Console.WriteLine("Successfully deleted MaintainerTeam with ID {0}", id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh-oh...");
                Console.WriteLine(e.Message);
            }
        } 
        public static void MaintainerTeam()
        {
            var menu = new ConsoleMenu();
            foreach (MaintainerTeam c in RestService.Get<MaintainerTeam>("/api/MaintainerTeam/"))
            {
                menu.Add($"{c.NAME}: {c.ID}", () => RESTMaintainerTeam(c.ID));
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }
    }
}