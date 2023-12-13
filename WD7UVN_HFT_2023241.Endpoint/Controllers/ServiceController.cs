using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using System;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/Service")]
    public class ServiceController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public ServiceController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
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
        }

[HttpPost()]
        public void UpdateService([FromBody] Service e)
        {
            LogicServices.CRUDOperations.UpdateService(e);
        }

        [HttpDelete()]
        public void DeleteService([FromBody] int id)
        {
            LogicServices.CRUDOperations.DeleteService(id);
        }
    }
}
