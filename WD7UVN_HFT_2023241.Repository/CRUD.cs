using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_HFT_2023241.Repository;

namespace WD7UVN_HFT_2023241.Repository
{
    public interface ICustomerRepository
    {
        public void CreateCustomer(Customer customer);
        public Customer ReadCustomer(int customerId);
        public IQueryable<Customer> ReadAllCustomers();
        public void UpdateCustomer(Customer updatedCustomer);
        public void DeleteCustomer(int customerId);
    }

    public interface IMaintainerTeamRepository
    {
        public void CreateMaintainerTeam(MaintainerTeam maintainerTeam);
        public MaintainerTeam ReadMaintainerTeam(int maintainerTeamId);
        public IQueryable<MaintainerTeam> ReadAllMaintainerTeams();
        public void UpdateMaintainerTeam(MaintainerTeam updatedMaintainerTeam);
        public void DeleteMaintainerTeam(int maintainerTeamId);
    }

    public interface IServiceRepository
    {
        public void CreateService(Service service);
        public Service ReadService(int serviceId);
        public IQueryable<Service> ReadAllServices();
        public void UpdateService(Service updatedService);
        public void DeleteService(int serviceId);
    }

    public interface IEmployeeRepository
    {
        public void CreateEmployee(Employee employee);
        public Employee ReadEmployee(int employeeId);
        public IQueryable<Employee> ReadAllEmployees();
        public void UpdateEmployee(Employee updatedEmployee);
        public void DeleteEmployee(int employeeId);
    }

    public interface ICRUD : ICustomerRepository, IEmployeeRepository, IMaintainerTeamRepository, IServiceRepository { }

	public class CRUD : ICRUD
	{
        public void CreateEmployee(Employee employee)
        {
            Database.Context.Employees.Add(employee);
            Database.Context.SaveChanges();
        }

        public Employee ReadEmployee(int employeeId)
        {
            return Database.Context.Employees.Find(employeeId);
        }

        public IQueryable<Employee> ReadAllEmployees()
        {
            return Database.Context.Employees.AsQueryable();
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            Employee existingEmployee = Database.Context.Employees.Find(updatedEmployee.ID);
            if (existingEmployee != null)
            {
                Database.Context.Entry(existingEmployee).CurrentValues.SetValues(updatedEmployee);
                Database.Context.SaveChanges();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            Employee employeeToDelete = Database.Context.Employees.Find(employeeId);
            if (employeeToDelete != null)
            {
                Database.Context.Employees.Remove(employeeToDelete);
                Database.Context.SaveChanges();
            }
        }

        public void CreateService(Service service)
        {
            Database.Context.Services.Add(service);
            Database.Context.SaveChanges();
        }

        public Service ReadService(int serviceId)
        {
            return Database.Context.Services.Find(serviceId);
        }

        public IQueryable<Service> ReadAllServices()
        {
            return Database.Context.Services.AsQueryable();
        }

        public void UpdateService(Service updatedService)
        {
            Service existingService = Database.Context.Services.Find(updatedService.ID);
            if (existingService != null)
            {
                Database.Context.Entry(existingService).CurrentValues.SetValues(updatedService);
                Database.Context.SaveChanges();
            }
        }

        public void DeleteService(int serviceId)
        {
            Service serviceToDelete = Database.Context.Services.Find(serviceId);
            if (serviceToDelete != null)
            {
                Database.Context.Services.Remove(serviceToDelete);
                Database.Context.SaveChanges();
            }
        }

        public void CreateMaintainerTeam(MaintainerTeam maintainerTeam)
        {
            Database.Context.Maintainers.Add(maintainerTeam);
            Database.Context.SaveChanges();
        }

        public MaintainerTeam ReadMaintainerTeam(int maintainerTeamId)
        {
            return Database.Context.Maintainers.Find(maintainerTeamId);
        }

        public IQueryable<MaintainerTeam> ReadAllMaintainerTeams()
        {
            return Database.Context.Maintainers.AsQueryable();
        }

        public void UpdateMaintainerTeam(MaintainerTeam updatedMaintainerTeam)
        {
            MaintainerTeam existingMaintainerTeam = Database.Context.Maintainers.Find(updatedMaintainerTeam.ID);
            if (existingMaintainerTeam != null)
            {
                Database.Context.Entry(existingMaintainerTeam).CurrentValues.SetValues(updatedMaintainerTeam);
                Database.Context.SaveChanges();
            }
        }

        public void DeleteMaintainerTeam(int maintainerTeamId)
        {
            MaintainerTeam maintainerTeamToDelete = Database.Context.Maintainers.Find(maintainerTeamId);
            if (maintainerTeamToDelete != null)
            {
                Database.Context.Maintainers.Remove(maintainerTeamToDelete);
                Database.Context.SaveChanges();
            }
        }

        public void CreateCustomer(Customer customer)
        {
            Database.Context.Customers.Add(customer);
            Database.Context.SaveChanges();
        }

        public Customer ReadCustomer(int customerId)
        {
            return Database.Context.Customers.Find(customerId);
        }

        public IQueryable<Customer> ReadAllCustomers()
        {
            return Database.Context.Customers.AsQueryable();
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            Customer existingCustomer = Database.Context.Customers.Find(updatedCustomer.ID);
            if (existingCustomer != null)
            {
                Database.Context.Entry(existingCustomer).CurrentValues.SetValues(updatedCustomer);
                Database.Context.SaveChanges();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customerToDelete = Database.Context.Customers.Find(customerId);
            if (customerToDelete != null)
            {
                Database.Context.Customers.Remove(customerToDelete);
                Database.Context.SaveChanges();
            }
        }
	}
	
}
