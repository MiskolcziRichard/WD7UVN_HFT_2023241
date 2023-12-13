using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using System;
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
        public IQueryable<MaintainerTeam>? ReadAllMaintainerTeams()
        {
            try
            {
                return LogicServices.CRUDOperations.ReadAllMaintainerTeams();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public MaintainerTeam? ReadMaintainerTeam(int id)
        {
            try
            {
                return LogicServices.CRUDOperations.ReadMaintainerTeam(id);
            }
            catch (NullReferenceException)
            {
                return null;
            }
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
