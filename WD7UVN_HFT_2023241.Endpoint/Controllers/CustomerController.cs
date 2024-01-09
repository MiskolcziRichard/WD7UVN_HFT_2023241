using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using WD7UVN_HFT_2023241.Models;
using System;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public CustomerController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
        }

        [HttpGet()]
        public IQueryable<Customer>? ReadAllCustomers()
        {
            try
            {
                return LogicServices.CRUDOperations.ReadAllCustomers();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public Customer? ReadCustomer(int id)
        {
            try
            {
                return LogicServices.CRUDOperations.ReadCustomer(id);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        [HttpPut()]
        public void PutCustomer([FromBody] Customer e)
        {
            LogicServices.CRUDOperations.CreateCustomer(e);
        }

        [HttpPost()]
        public void UpdateCustomer([FromBody] Customer e)
        {
            LogicServices.CRUDOperations.UpdateCustomer(e);
        }

        //HttpClient does not support sending data in the body of a DELETE request. Instead, we can send the data in the URL like with a GET request.
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            LogicServices.CRUDOperations.DeleteCustomer(id);
        }
    }
}
