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
            return Ok("This is a GET request.");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"Received POST request with value: {value}");
        }
    }
}
