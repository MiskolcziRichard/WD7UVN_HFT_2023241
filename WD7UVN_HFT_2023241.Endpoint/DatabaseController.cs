using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public DatabaseController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
			// Accessing individual query parameters
			//string paramValue = HttpContext.Request.Query["tableName"];
			
			// Retrieving all query parameters
			var queryParams = HttpContext.Request.Query;
			
			foreach (var param in queryParams)
			{
				string paramName = param.Key;
				string paramVal = param.Value;

				// Perform operations with paramName and paramVal
				
			}
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"Received POST request with value: {value}");
        }
    }
}
