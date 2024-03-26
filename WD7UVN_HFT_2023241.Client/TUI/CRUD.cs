using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using ConsoleTools;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_HFT_2023241.Client.Shared;

namespace WD7UVN_HFT_2023241.Client.TUI
{
    public class CRUD 
    {
        public delegate void CRUDMethod<T>(T obj);

        private static void MethodChooser<T>(CRUDActions action)
        {
            CRUDMethod<T> method = null;
            switch (action)
            {
                case CRUDActions.GetAll:
                    method = View.DisplayAll;
                    break;
                case CRUDActions.GetById:
                    method = View.Display;
                    break;
                case CRUDActions.Create:
                    method = Modify.Create;
                    break;
                case CRUDActions.Update:
                    method = Modify.Update;
                    break;
                case CRUDActions.Delete:
                    method = Modify.Delete;
                    break;
            }

            ShowMenu<T>(method);
        }

        public static void TypeSelectorMenu(CRUDActions action)
        {
            var menu = new ConsoleMenu();
            menu.Add("Customer", () => MethodChooser<Customer>(action));
            menu.Add("Employee", () => MethodChooser<Employee>(action));
            menu.Add("Service", () => MethodChooser<Service>(action));
            menu.Add("Maintainer team", () => MethodChooser<MaintainerTeam>(action));
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }

        public static void ShowMenu<T>(CRUDMethod<T> method)
        {
            var menu = new ConsoleMenu();

            if (method != Modify.Create && method != View.DisplayAll)
            {
                foreach (T c in RestService.Get<T>("/api/" + typeof(T).Name + "/"))
                {
                    menu.Add($"{c.GetType().GetProperty("NAME").GetValue(c)}: {c.GetType().GetProperty("ID").GetValue(c)}", () => method(c));
                }
            }
            else
            {
                method(default);
            }
            menu.Add("Back", ConsoleMenu.Close);
            menu.Show();
        }
    }

    public class Modify
    {
        public static void Delete<T>(T c)
        {
            try
            {
                int key = (int)c.GetType().GetProperty("ID").GetValue(c);

                RestService.Delete(key, "/api/" + typeof(T).Name + "/");
                Console.WriteLine("Successfully deleted {0} with ID {1}", typeof(T).Name, key);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("The following error occured:");
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        public static void Update<T>(T item)
        {
            View.Display(item);
            Console.WriteLine("Now you can modify these fields, except for the ID.");

            try
            {
                foreach (PropertyInfo p in item.GetType().GetProperties())
                {
                    if (p.Name != "ID")
                    {
                        Console.Write(p.Name + " (" + p.PropertyType.Name + "): ");
                        string input = Console.ReadLine();
                        if (p.PropertyType.Name == "Int32")
                        {
                            p.SetValue(item, Convert.ToInt32(input));
                        }
                        else
                        {
                            p.SetValue(item, input);
                        }
                    }
                }

                RestService.Post<T>(item, "/api/" + typeof(T).Name + "/");

                Console.WriteLine("\nSuccessfully updated {0} with ID {1}", typeof(T).Name, item.GetType().GetProperty("ID").GetValue(item));
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format!");
            }
        }

        public static void Create<T>(T? dummy = default)
        {
            try
            {
                T item = (T)Activator.CreateInstance(typeof(T));

                Console.WriteLine("Please supply all neccessary fields!");

                foreach (PropertyInfo p in item.GetType().GetProperties())
                {
                    Console.Write(p.Name + " (" + p.PropertyType.Name + "): ");
                    string input = Console.ReadLine();
                    if (p.PropertyType.Name == "Int32")
                    {
                        p.SetValue(item, Convert.ToInt32(input));
                    }
                    else
                    {
                        p.SetValue(item, input);
                    }
                }

                RestService.Put<T>(item, "/api/" + typeof(T).Name + "/");

                Console.WriteLine("\nSuccessfully created {0} with ID {1}", typeof(T).Name, item.GetType().GetProperty("ID").GetValue(item));
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format!");
            }
        }
    }

    internal class View
    {
        internal static void Display<T>(T c)
        {
            if (c != null)
            {
                foreach (PropertyInfo p in c.GetType().GetProperties())
                {
                    Console.WriteLine(p.Name + ": " + p.GetValue(c));
                }
            }
            else
            {
                Console.WriteLine("No such database entry was found :/");
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        internal static void DisplayAll<T>(T? dummy = default)
        {
            var items = RestService.Get<T>("/api/" + typeof(T).Name + "/");
            if (items != null)
            {
                foreach (T item in items)
                {
                    foreach (PropertyInfo p in item.GetType().GetProperties())
                    {
                        Console.WriteLine(p.Name + ": " + p.GetValue(item));
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No such database entry was found :/");
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
    }
}