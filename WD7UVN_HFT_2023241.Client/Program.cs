using System;

namespace WD7UVN_HFT_2023241.Client
{
    class Program
    {
        static bool FLAG = true;
        static RestService rest = new RestService();

        static void Main(string[] args)
        {
            ActionMenuHandler();
        }

        static void ActionMenuHandler()
        {
            while (FLAG)
            {
                int choice = ActionMenu();
                if (choice == 6)
                {
                    NonCRUDMenuHandler();
                }
                else if (choice == 0)
                {
                    FLAG = false;
                }
                else if (1 <= choice && choice <= 5)
                {
                    switch (TypeSelectorMenu())
                    {
                        case 1:
                            if (choice == 1) { Read.Employee(); }
                            else if (choice == 2) { ReadAll.Employee(); }
                            else if (choice == 3) { Create.Employee(); }
                            else if (choice == 4) { Update.Employee(); }
                            else if (choice == 5) { Delete.Employee(); }
                            break;
                        case 2:
                            if (choice == 1) { Read.Customer(); }
                            else if (choice == 2) { ReadAll.Customer(); }
                            else if (choice == 3) { Create.Customer(); }
                            else if (choice == 4) { Update.Customer(); }
                            else if (choice == 5) { Delete.Customer(); }
                            break;
                        case 3:
                            if (choice == 1) { Read.Service(); }
                            else if (choice == 2) { ReadAll.Service(); }
                            else if (choice == 3) { Create.Service(); }
                            else if (choice == 4) { Update.Service(); }
                            else if (choice == 5) { Delete.Service(); }
                            break;
                        case 4:
                            if (choice == 1) { Read.MaintainerTeam(); }
                            else if (choice == 2) { ReadAll.MaintainerTeam(); }
                            else if (choice == 3) { Create.MaintainerTeam(); }
                            else if (choice == 4) { Update.MaintainerTeam(); }
                            else if (choice == 5) { Delete.MaintainerTeam(); }
                            break;
                    }
                }
            }
        }

        static int TypeSelectorMenu()
        {
            Console.Clear();
            Console.WriteLine("1.) Employee");
            Console.WriteLine("2.) Customer");
            Console.WriteLine("3.) Service");
            Console.WriteLine("4.) MaintainerTeam");

            while (true)
            {
                try
                {
                    Console.Write("Your choice: ");
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number");
                }
            }

        }

        static int ReadMenuHandler()
        {
            Console.Clear();
            Console.WriteLine("1.) ");

            while (true)
            {
                try
                {
                    Console.Write("Your choice: ");
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number");
                }
            }
        }

        static void NonCRUDMenuHandler()
        {
            switch (NonCRUDMenu())
            {
                case 1:
                    NonCRUD.WhoWorksInMaintainerTeam();
                    break;
                case 2:
                    NonCRUD.GetSubordinates();
                    break;
                case 3:
                    NonCRUD.WhoUsesService();
                    break;
                case 4:
                    NonCRUD.WhoIsResponsibleForService();
                    break;
                case 5:
                    NonCRUD.WhoMaintainsService();
                    break;
            }
        }


        static int NonCRUDMenu()
        {
            Console.Clear();
            Console.WriteLine("1.) Who works in specified maintainer team?");
            Console.WriteLine("2.) Get manager's subordinates");
            Console.WriteLine("3.) Which client(s) use(s) specified service?");
            Console.WriteLine("4.) Who (which manager) is responsible for a specified service?");
            Console.WriteLine("5.) Get all employees who maintain a specified service");

            while (true)
            {
                try
                {
                    Console.Write("Your choice: ");
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number");
                }
            }
        }

        static int ActionMenu()
        {
            Console.Clear();
            Console.WriteLine("1.) Read");
            Console.WriteLine("2.) ReadAll");
            Console.WriteLine("3.) Create");
            Console.WriteLine("4.) Update");
            Console.WriteLine("5.) Delete");
            Console.WriteLine("6.) Non-CRUD");
            Console.WriteLine("0.) Exit");

            while (true)
            {
                try
                {
                    Console.Write("Your choice: ");
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number");
                }
            }
        }
    }
}
