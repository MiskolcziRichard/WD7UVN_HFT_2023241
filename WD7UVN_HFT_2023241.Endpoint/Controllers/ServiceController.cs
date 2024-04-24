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
    [Route("api/Service")]
    public class ServiceController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }
        IHubContext<SignalRHub> hub;

        public ServiceController(ILogicServices LogicServices, IHubContext<SignalRHub> hub)
        {
            this.LogicServices = LogicServices;
            this.hub = hub;
        }

        [HttpGet()]
        public IQueryable<Service>? ReadAllServices()
        {
            try
            {
                return LogicServices.CRUDOperations.ReadAllServices();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public Service? ReadService(int id)
        {
            try
            {
                return LogicServices.CRUDOperations.ReadService(id);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        [HttpPut()]
        public void PutService([FromBody] Service e)
        {
            LogicServices.CRUDOperations.CreateService(e);
            hub.Clients.All.SendAsync("ServiceCreated", e);
        }

        [HttpPost()]
        public void UpdateService([FromBody] Service e)
        {
            LogicServices.CRUDOperations.UpdateService(e);
            hub.Clients.All.SendAsync("ServiceUpdated", e);
        }

        //HttpClient does not support sending data in the body of a DELETE request. Instead, we can send the data in the URL like with a GET request.
        [HttpDelete("{id}")]
        public void DeleteService(int id)
        {
            Service service = LogicServices.CRUDOperations.ReadService(id);
            LogicServices.CRUDOperations.DeleteService(id);
            hub.Clients.All.SendAsync("ServiceDeleted", service);
        }
    }
}
