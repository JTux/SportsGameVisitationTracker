using Microsoft.AspNet.Identity;
using StadiumTracker.Models.TeamModels;
using StadiumTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StadiumTracker.WebAPI.Controllers
{
    [Authorize]
    public class TeamController : ApiController
    {
        public IHttpActionResult Get() => Ok(CreateTeamService().GetAllTeams());

        public IHttpActionResult Get(int? id)
        {
            if (id == null)
                return BadRequest();

            TeamService service = CreateTeamService();

            return Ok(service.GetTeamByID(id.Value));
        }

        public IHttpActionResult Post(TeamCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TeamService service = CreateTeamService();

            if (service.CreateTeam(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Put(TeamEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TeamService service = CreateTeamService();

            if (service.UpdateExistingTeam(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            TeamService service = CreateTeamService();

            if (service.DeleteTeam(id.Value))
                return Ok();

            return InternalServerError();
        }

        private TeamService CreateTeamService() => new TeamService(Guid.Parse(User.Identity.GetUserId()), User.IsInRole("Admin"));
    }
}
