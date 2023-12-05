using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using WD7UVN_HFT_2023241.Models;

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

		[HttpGet("{id}")]
		public IQueryable<Employee> WhoWorksInMaintainerTeam(int id)
		{
			return LogicServices.WhoWorksInMaintainerTeam(id);
		}
    }
}
