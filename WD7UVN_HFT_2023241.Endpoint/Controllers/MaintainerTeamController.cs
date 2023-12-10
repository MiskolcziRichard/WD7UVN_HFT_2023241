using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/MaintainerTeam")]
    public class MaintainerTeamController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }

        public MaintainerTeamController(ILogicServices LogicServices)
        {
            this.LogicServices = LogicServices;
        }

        [HttpGet()]
        public IQueryable<MaintainerTeam> ReadAllMaintainerTeams()
        {
            return LogicServices.CRUDOperations.ReadAllMaintainerTeams();
        }

        [HttpGet("{id}")]
        public MaintainerTeam ReadMaintainerTeam([FromQuery] int id)
        {
            return LogicServices.CRUDOperations.ReadMaintainerTeam(id);
        }

[HttpPut()]
        public void PutMaintainerTeam([FromBody] MaintainerTeam e)
        {
            LogicServices.CRUDOperations.CreateMaintainerTeam(e);
        }

[HttpPost()]
        public void UpdateMaintainerTeam([FromBody] MaintainerTeam e)
        {
            LogicServices.CRUDOperations.UpdateMaintainerTeam(e);
        }

        [HttpDelete()]
        public void DeleteMaintainerTeam([FromBody] int id)
        {
            LogicServices.CRUDOperations.DeleteMaintainerTeam(id);
        }
    }
}
