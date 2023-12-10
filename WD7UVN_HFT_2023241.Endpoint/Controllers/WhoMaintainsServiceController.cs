using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/WhoMaintainsService")]
    public class WhoMaintainsServiceController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public WhoMaintainsServiceController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
        }

		[HttpGet("{id}")]
		public IQueryable<Customer> WhoUsesService([FromQuery] int id)
		{
			return LogicServices.WhoUsesService(id);
		}
    }
}
