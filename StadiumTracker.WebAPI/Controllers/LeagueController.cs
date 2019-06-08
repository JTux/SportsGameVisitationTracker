using Microsoft.AspNet.Identity;
using StadiumTracker.Models.LeagueModels;
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
    public class LeagueController : ApiController
    {
        public IHttpActionResult Get()
        {
            LeagueService service = CreateLeagueService();
            var leagues = service.GetAllLeagues();
            return Ok(leagues);
        }

        public IHttpActionResult Get(int? id)
        {
            if (id == null)
                return BadRequest();

            LeagueService service = CreateLeagueService();

            return Ok(service.GetLeagueByID(id.Value));
        }

        public IHttpActionResult Post(LeagueCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            LeagueService service = CreateLeagueService();

            if (service.CreateLeague(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Put(LeagueEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            LeagueService service = CreateLeagueService();

            if (service.UpdateExistingLeague(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            LeagueService service = CreateLeagueService();

            if (service.DeleteLeague(id.Value))
                return Ok();

            return InternalServerError();
        }

        private LeagueService CreateLeagueService() => new LeagueService(Guid.Parse(User.Identity.GetUserId()), User.IsInRole("Admin"));
    }
}
