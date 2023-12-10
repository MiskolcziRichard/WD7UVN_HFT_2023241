using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/GetSubordinates")]
    public class GetSubordinatesController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public GetSubordinatesController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
        }

		[HttpGet("{id}")]
		public IQueryable<Employee> GetSubordinates([FromQuery] int id)
		{
			return LogicServices.GetSubordinates(id);
		}
    }
}
