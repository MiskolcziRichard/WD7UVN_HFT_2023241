using System;
using System.Linq;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_HFT_2023241.Repository;

namespace WD7UVN_HFT_2023241.Logic
{
    public interface ILogicServices
    {
        public ICRUD CRUDOperations { get; set; }

        //additional, non-CRUD operations
        public IQueryable<Employee> WhoWorksInMaintainerTeam(int maintainerTeamId);
        public IQueryable<Employee> GetSubordinates(int managerId);
        public IQueryable<Customer> WhoUsesService(int serviceId);
		public Employee WhoIsResponsibleForService(int serviceId);
		public IQueryable<Employee> WhoMaintainsService(int serviceId);
    }

    public class LogicServices : ILogicServices
    {
        public ICRUD CRUDOperations { get; set; }

        public LogicServices(ICRUD CRUDOperations)
        {
            this.CRUDOperations = CRUDOperations;
        }

		public IQueryable<Employee> WhoMaintainsService(int serviceId)
		{
			IQueryable<Employee> query =
				from employee in CRUDOperations.ReadAllEmployees()
				join service in CRUDOperations.ReadAllServices() on employee.MAINTAINER_ID equals service.MAINTAINER_ID
				where service.ID == serviceId
				select employee;

			return query;
		}

		public Employee WhoIsResponsibleForService(int serviceId)
		{
			var query =
				from service in CRUDOperations.ReadAllServices()
				join team in CRUDOperations.ReadAllMaintainerTeams() on service.MAINTAINER_ID equals team.ID
				join employee in CRUDOperations.ReadAllEmployees() on team.LEADER_ID equals employee.ID
				where service.ID == serviceId
				select employee;

			return query.FirstOrDefault();
		}

public IQueryable<Employee> WhoWorksInMaintainerTeam(int maintainerTeamId)
        {
            return CRUDOperations
            .ReadAllEmployees()
            .Where(e => e.MAINTAINER_ID == maintainerTeamId);
        }

        public IQueryable<Employee> GetSubordinates(int managerId)
        {
            return CRUDOperations
            .ReadAllEmployees()
            .Where(e => e.MANAGER_ID == managerId);
        }

        public IQueryable<Customer> WhoUsesService(int serviceId)
        {
            return CRUDOperations
            .ReadAllCustomers()
            .Where(c => c.SERVICE_ID == serviceId);
        }
    }
}
