using Microsoft.AspNetCore.Mvc;
using System;
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

		[HttpGet()]
		public IQueryable<Employee>? WhoUsesService([FromQuery] int id)
		{
            try
            {
			    return LogicServices.WhoMaintainsService(id);
            }
            catch (NullReferenceException)
            {
                return null;
            }
		}
    }
}
