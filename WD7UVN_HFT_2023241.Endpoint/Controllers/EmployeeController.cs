using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using System;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public EmployeeController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
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
        }

        [HttpPost()]
        public void UpdateEmployee([FromBody] Employee e)
        {
            LogicServices.CRUDOperations.UpdateEmployee(e);
        }

        [HttpDelete()]
        public void DeleteEmployee([FromBody] int id)
        {
            LogicServices.CRUDOperations.DeleteEmployee(id);
        }
    }
}
