using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/database")]
    public class CustomerController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public CustomerController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
        }

        [HttpGet()]
        public IActionResult ReadAllCustomers()
        {
            return View(LogicServices.CRUDOperations.ReadAllCustomers());
        }

        [HttpGet("{id}")]
        public Customer ReadCustomer(int id)
        {
            return LogicServices.CRUDOperations.ReadCustomer(id);
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

        [HttpDelete()]
        public void DeleteCustomer([FromBody] int id)
        {
            LogicServices.CRUDOperations.DeleteCustomer(id);
        }
    }
}
