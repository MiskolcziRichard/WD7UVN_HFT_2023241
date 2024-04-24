using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using System;
using WD7UVN_HFT_2023241.Models;
using Microsoft.AspNetCore.SignalR;
using WD7UVN_HFT_2023241.Endpoint.Services;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }
        IHubContext<SignalRHub> hub;

        public EmployeeController(ILogicServices LogicServices, IHubContext<SignalRHub> hub)
        {
            this.LogicServices = LogicServices;
            this.hub = hub;
        }

        [HttpGet()]
        public IQueryable<Employee>? ReadAllEmployees()
        {
            try
            {
                return LogicServices.CRUDOperations.ReadAllEmployees();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public Employee? ReadEmployee(int id)
        {
            try
            {
                return LogicServices.CRUDOperations.ReadEmployee(id);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        [HttpPut()]
        public void PutEmployee([FromBody] Employee e)
        {
            LogicServices.CRUDOperations.CreateEmployee(e);
            hub.Clients.All.SendAsync("EmployeeCreated", e);
        }

        [HttpPost()]
        public void UpdateEmployee([FromBody] Employee e)
        {
            LogicServices.CRUDOperations.UpdateEmployee(e);
            hub.Clients.All.SendAsync("EmployeeUpdated", e);
        }

        //HttpClient does not support sending data in the body of a DELETE request. Instead, we can send the data in the URL like with a GET request.
        [HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
            Employee e = LogicServices.CRUDOperations.ReadEmployee(id);
            LogicServices.CRUDOperations.DeleteEmployee(id);
            hub.Clients.All.SendAsync("EmployeeDeleted", e);
        }
    }
}
