using Microsoft.AspNetCore.Mvc;
using System;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using WD7UVN_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/WhoWorksInMaintainerTeam")]
    public class WhoWorksInMaintainerTeamController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public WhoWorksInMaintainerTeamController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
        }

		[HttpGet()]
		public IQueryable<Employee>? WhoWorksInMaintainerTeam([FromQuery] int id)
		{
            try
            {
			    return LogicServices.WhoWorksInMaintainerTeam(id);
            }
            catch (NullReferenceException)
            {
                return null;
            }
		}
    }
}
