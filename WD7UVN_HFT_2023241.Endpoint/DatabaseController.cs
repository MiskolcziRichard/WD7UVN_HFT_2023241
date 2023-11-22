using WD7UVN_HFT_2023241.Logic;
using Microsoft.AspNetCore.Mvc;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
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
