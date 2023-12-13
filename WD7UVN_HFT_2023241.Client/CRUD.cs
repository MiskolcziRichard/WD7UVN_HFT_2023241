using System;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Client
{
    public class Read
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
            Console.WriteLine("ID: " + c.ID);
            Console.WriteLine("Email: " + c.EMAIL);
            Console.WriteLine("Phone: " + c.PHONE);
            Console.WriteLine("ID of used service: " + c.SERVICE_ID);
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
        }   

        public static void MaintainerTeam()
        {

            int input;
            while (true)
            {
                try
                {
                    Console.Write("Enter a number for the team's ID: ");
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
        } 
    }

    public class ReadAll
    {
        public static void Customer()
        {

            foreach (Customer c in RestService.Get<Customer>("/api/Customer"))
            {
                Console.WriteLine("Name: " + c.NAME);
                Console.WriteLine("ID: " + c.ID);
                Console.WriteLine("Email: " + c.EMAIL);
                Console.WriteLine("Phone: " + c.PHONE);
                Console.WriteLine("ID of used service: " + c.SERVICE_ID);
                Console.WriteLine();
            }
        }

        public static void Employee()
        {

            foreach (Employee c in RestService.Get<Employee>("/api/Employee"))
            {
                Console.WriteLine("Name: " + c.NAME);
                Console.WriteLine("ID: " + c.ID);
                Console.WriteLine("Email: " + c.EMAIL);
                Console.WriteLine("Phone: " + c.PHONE);
                Console.WriteLine("Maintainer team's ID: " + c.MAINTAINER_ID);
                Console.WriteLine("Manager's ID: " + c.MANAGER_ID);
                Console.WriteLine();
            }
        }

        public static void Service()
        {

            foreach (Service c in RestService.Get<Service>("/api/Service"))
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
        }   

        public static void MaintainerTeam()
        {

            foreach (MaintainerTeam c in RestService.Get<MaintainerTeam>("/api/MaintainerTeam"))
            {
                Console.WriteLine("Name: " + c.NAME);
                Console.WriteLine("ID: " + c.ID);
                Console.WriteLine("Email: " + c.EMAIL);
                Console.WriteLine("Leader's ID: " + c.LEADER_ID);
                Console.WriteLine();
            }
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

                    RestService.Put<Customer>(c, "/api/Customer");

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

                    RestService.Put<Employee>(c, "/api/Employee");

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

                    Console.Write("Version (integer): ");
                    int version = Convert.ToInt32(Console.ReadLine());

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

                    RestService.Put<Service>(c, "/api/Service");

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

                    RestService.Put<MaintainerTeam>(c, "/api/MaintainerTeam");

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

                    RestService.Post<Customer>(c, "/api/Customer");
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

                    RestService.Post<Employee>(c, "/api/Employee");
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

                    Console.Write("Version (integer): ");
                    int version = Convert.ToInt32(Console.ReadLine());

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

                    RestService.Post<Service>(c, "/api/Service");
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

                    RestService.Post<MaintainerTeam>(c, "/api/MaintainerTeam");
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

            try
            {
                RestService.Delete(input, "/api/Customer/");
                Console.WriteLine("Successfully deleted Customer with ID {0}", input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh-oh...");
                Console.WriteLine(e.Message);
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

            try
            {
                RestService.Delete(input, "/api/Employee/");
                Console.WriteLine("Successfully deleted Employee with ID {0}", input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh-oh...");
                Console.WriteLine(e.Message);
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

            try
            {
                RestService.Delete(input, "/api/Service/");
                Console.WriteLine("Successfully deleted Service with ID {0}", input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh-oh...");
                Console.WriteLine(e.Message);
            }
        }   

        public static void MaintainerTeam()
        {

            int input;
            while (true)
            {
                try
                {
                    Console.Write("Enter a number for the team's ID: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number.");
                }
            }

            try
            {
                RestService.Delete(input, "/api/MaintainerTeam/");
                Console.WriteLine("Successfully deleted MaintainerTeam with ID {0}", input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh-oh...");
                Console.WriteLine(e.Message);
            }
        } 
    }
}