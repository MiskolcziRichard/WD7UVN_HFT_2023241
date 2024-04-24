using Microsoft.AspNetCore.Mvc;
using WD7UVN_HFT_2023241.Logic;
using System.Linq;
using System;
using WD7UVN_HFT_2023241.Models;
using Microsoft.AspNetCore.SignalR;
using WD7UVN_HFT_2023241.Endpoint.Services;

namespace WD7UVN_HFT_2023241.Endpoint
{
    [ApiController]
    [Route("api/MaintainerTeam")]
    public class MaintainerTeamController : ControllerBase
    {
        public ILogicServices LogicServices { get; set; }
        IHubContext<SignalRHub> hub;

        public MaintainerTeamController(ILogicServices LogicServices, IHubContext<SignalRHub> hub)
        {
            this.LogicServices = LogicServices;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("MaintainerTeamCreated", e);
        }

        [HttpPost()]
        public void UpdateMaintainerTeam([FromBody] MaintainerTeam e)
        {
            LogicServices.CRUDOperations.UpdateMaintainerTeam(e);
            hub.Clients.All.SendAsync("MaintainerTeamUpdated", e);
        }

        //HttpClient does not support sending data in the body of a DELETE request. Instead, we can send the data in the URL like with a GET request.
        [HttpDelete("{id}")]
        public void DeleteMaintainerTeam(int id)
        {
            MaintainerTeam maintainerTeam = LogicServices.CRUDOperations.ReadMaintainerTeam(id);
            LogicServices.CRUDOperations.DeleteMaintainerTeam(id);
            hub.Clients.All.SendAsync("MaintainerTeamDeleted", maintainerTeam);
        }
    }
}
