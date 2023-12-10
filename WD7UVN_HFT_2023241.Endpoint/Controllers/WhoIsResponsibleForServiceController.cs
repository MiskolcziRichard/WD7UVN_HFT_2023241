using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/WhoIsResponsibleForService")]
    public class WhoIsReponsibleForServiceController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public WhoIsReponsibleForServiceController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
        }

		[HttpGet()]
		public Employee WhoIsResponsibleForService([FromQuery] int id)
		{
            return LogicServices.WhoIsResponsibleForService(id);
        }
    }
}
