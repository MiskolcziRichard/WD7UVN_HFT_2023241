using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/WhoUsesService")]
    public class WhoUsesServiceController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public WhoUsesServiceController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
        }

		[HttpGet()]
		public IQueryable<Customer> WhoUsesService([FromQuery] int id)
		{
			return LogicServices.WhoUsesService(id);
		}
    }
}
