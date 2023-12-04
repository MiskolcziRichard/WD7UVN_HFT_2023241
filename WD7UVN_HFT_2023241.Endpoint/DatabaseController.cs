using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using WD7UVN_HFT_2023241.Models;
using System.Collections;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/database")]
    public class DatabaseController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public DatabaseController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
        }

        [HttpGet("Employees")]
        public IQueryable<Employee> ReadAllEmployees()
        {
            return LogicServices.CRUDOperations.ReadAllEmployees();
        }

        [HttpGet("Services")]
        public IQueryable<Service> ReadAllServices()
        {
            return LogicServices.CRUDOperations.ReadAllServices();
        }

        [HttpGet("MaintainerTeams")]
        public IQueryable<MaintainerTeam> ReadAllMaintainerTeams()
        {
            return LogicServices.CRUDOperations.ReadAllMaintainerTeams();
        }

        [HttpGet("Customer")]
        public IQueryable<Customer> ReadAllCustomers()
        {
            return LogicServices.CRUDOperations.ReadAllCustomers();
        }

        [HttpGet("MaintainerTeam/{id}")]
        public MaintainerTeam ReadMaintainerTeam(int id)
        {
            return LogicServices.CRUDOperations.ReadMaintainerTeam(id);
        }

        [HttpGet("Service/{id}")]
        public Service ReadService(int id)
        {
            return LogicServices.CRUDOperations.ReadService(id);
        }

        [HttpGet("Customer/{id}")]
        public Customer ReadCustomer(int id)
        {
            return LogicServices.CRUDOperations.ReadCustomer(id);
        }

        [HttpGet("Employee/{id}")]
        public Employee ReadEmployee(int id)
        {
            return LogicServices.CRUDOperations.ReadEmployee(id);
        }

        [HttpPut("Employee")]
        public void PutEmployee([FromBody] Employee e)
        {
            LogicServices.CRUDOperations.CreateEmployee(e);
        }

        [HttpPut("Customer")]
        public void PutCustomer([FromBody] Customer c)
        {
            LogicServices.CRUDOperations.CreateCustomer(c);
        }

        [HttpPut("Service")]
        public void PutService([FromBody] Service s)
        {
            LogicServices.CRUDOperations.CreateService(s);
        }

        [HttpPut("MaintainerTeam")]
        public void PutMaintainerTeam([FromBody] MaintainerTeam m)
        {
            LogicServices.CRUDOperations.CreateMaintainerTeam(m);
        }

        [HttpPost("Employee")]
        public void UpdateEmployee([FromBody] Employee e)
        {
            LogicServices.CRUDOperations.UpdateEmployee(e);
        }

        [HttpPost("Customer")]
        public void UpdateCustomer([FromBody] Customer c)
        {
            LogicServices.CRUDOperations.UpdateCustomer(c);
        }

        [HttpPost("Service")]
        public void UpdateService([FromBody] Service s)
        {
            LogicServices.CRUDOperations.UpdateService(s);
        }

        [HttpPost("MaintainerTeam")]
        public void UpdateMaintainerTeam([FromBody] MaintainerTeam m)
        {
            LogicServices.CRUDOperations.UpdateMaintainerTeam(m);
        }

        [HttpDelete("Employee")]
        public void DeleteEmployee([FromBody] int id)
        {
            LogicServices.CRUDOperations.DeleteEmployee(id);
        }

        [HttpDelete("MaintainerTeam")]
        public void DeleteMaintainerTeam([FromBody] int id)
        {
            LogicServices.CRUDOperations.DeleteMaintainerTeam(id);
        }

        [HttpDelete("Service")]
        public void DeleteService([FromBody] int id)
        {
            LogicServices.CRUDOperations.DeleteEmployee(id);
        }

        [HttpDelete("Customer")]
        public void DeleteCustomer([FromBody] int id)
        {
            LogicServices.CRUDOperations.DeleteEmployee(id);
        }
    }
}
