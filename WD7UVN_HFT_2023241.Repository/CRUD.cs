using System;
using Microsoft.EntityFrameworkCore;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_HFT_2023241.Repository;

namespace WD7UVN_HFT_2023241.Repository
{
    public class CustomerRepository
    {
        public static void CreateCustomer(Customer customer)
        {
            Database.Context.Customers.Add(customer);
            Database.Context.SaveChanges();
        }

        public static Customer ReadCustomer(int customerId)
        {
            return Database.Context.Customers.Find(customerId);
        }

        public static void UpdateCustomer(Customer updatedCustomer)
        {
            Customer existingCustomer = Database.Context.Customers.Find(updatedCustomer.ID);
            if (existingCustomer != null)
            {
                Database.Context.Entry(existingCustomer).CurrentValues.SetValues(updatedCustomer);
                Database.Context.SaveChanges();
            }
        }

        public static void DeleteCustomer(int customerId)
        {
            Customer customerToDelete = Database.Context.Customers.Find(customerId);
            if (customerToDelete != null)
            {
                Database.Context.Customers.Remove(customerToDelete);
                Database.Context.SaveChanges();
            }
        }
    }    

    public class MaintainerTeamRepository
    {
        public static void CreateMaintainerTeam(MaintainerTeam maintainerTeam)
        {
            Database.Context.Maintainers.Add(maintainerTeam);
            Database.Context.SaveChanges();
        }

        public static MaintainerTeam ReadMaintainerTeam(int maintainerTeamId)
        {
            return Database.Context.Maintainers.Find(maintainerTeamId);
        }

        public static void UpdateMaintainerTeam(MaintainerTeam updatedMaintainerTeam)
        {
            MaintainerTeam existingMaintainerTeam = Database.Context.Maintainers.Find(updatedMaintainerTeam.ID);
            if (existingMaintainerTeam != null)
            {
                Database.Context.Entry(existingMaintainerTeam).CurrentValues.SetValues(updatedMaintainerTeam);
                Database.Context.SaveChanges();
            }
        }

        public static void DeleteMaintainerTeam(int maintainerTeamId)
        {
            MaintainerTeam maintainerTeamToDelete = Database.Context.Maintainers.Find(maintainerTeamId);
            if (maintainerTeamToDelete != null)
            {
                Database.Context.Maintainers.Remove(maintainerTeamToDelete);
                Database.Context.SaveChanges();
            }
        }
    }

    public class ServiceRepository
    {
        public static void CreateService(Service service)
        {
            Database.Context.Services.Add(service);
            Database.Context.SaveChanges();
        }

        public static Service ReadService(int serviceId)
        {
            return Database.Context.Services.Find(serviceId);
        }

        public static void UpdateService(Service updatedService)
        {
            Service existingService = Database.Context.Services.Find(updatedService.ID);
            if (existingService != null)
            {
                Database.Context.Entry(existingService).CurrentValues.SetValues(updatedService);
                Database.Context.SaveChanges();
            }
        }

        public static void DeleteService(int serviceId)
        {
            Service serviceToDelete = Database.Context.Services.Find(serviceId);
            if (serviceToDelete != null)
            {
                Database.Context.Services.Remove(serviceToDelete);
                Database.Context.SaveChanges();
            }
        }
    }

    public class EmployeeRepository
    {
        public static void CreateEmployee(Employee employee)
        {
            Database.Context.Employees.Add(employee);
            Database.Context.SaveChanges();
        }

        public static Employee ReadEmployee(int employeeId)
        {
            return Database.Context.Employees.Find(employeeId);
        }

        public static void UpdateEmployee(Employee updatedEmployee)
        {
            Employee existingEmployee = Database.Context.Employees.Find(updatedEmployee.ID);
            if (existingEmployee != null)
            {
                Database.Context.Entry(existingEmployee).CurrentValues.SetValues(updatedEmployee);
                Database.Context.SaveChanges();
            }
        }

        public static void DeleteEmployee(int employeeId)
        {
            Employee employeeToDelete = Database.Context.Employees.Find(employeeId);
            if (employeeToDelete != null)
            {
                Database.Context.Employees.Remove(employeeToDelete);
                Database.Context.SaveChanges();
            }
        }
    }
}