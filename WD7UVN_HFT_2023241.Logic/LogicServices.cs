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

    public class LogicServices : ILogicServices
    {
        public ICRUD CRUDOperations { get; set; }

        public LogicServices(ICRUD CRUDOperations)
        {
            this.CRUDOperations = CRUDOperations;
        }
    }
}
