using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using WD7UVN_HFT_2023241.Models;
using System;
using Microsoft.AspNetCore.SignalR;
using WD7UVN_HFT_2023241.Endpoint.Services;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }
        IHubContext<SignalRHub> hub;

        public CustomerController(ILogicServices LogicServices, IHubContext<SignalRHub> hub)
        {
            this.LogicServices = LogicServices;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("CustomerCreated", e);
        }

        [HttpPost()]
        public void UpdateCustomer([FromBody] Customer e)
        {
            LogicServices.CRUDOperations.UpdateCustomer(e);
            hub.Clients.All.SendAsync("CustomerUpdated", e);
        }

        //HttpClient does not support sending data in the body of a DELETE request. Instead, we can send the data in the URL like with a GET request.
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            Customer customer = LogicServices.CRUDOperations.ReadCustomer(id);
            LogicServices.CRUDOperations.DeleteCustomer(id);
            hub.Clients.All.SendAsync("CustomerDeleted", customer);
        }
    }
}
