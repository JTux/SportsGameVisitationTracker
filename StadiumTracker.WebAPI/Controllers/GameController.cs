using Microsoft.AspNet.Identity;
using StadiumTracker.Models.GameModels;
using StadiumTracker.Models.VisitorModels;
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
    [RoutePrefix("api/Game")]
    public class GameController : ApiController
    {
        public IHttpActionResult Get()
        {
            GameService service = CreateGameService();
            return Ok(service.GetAllGames());
        }

        public IHttpActionResult Get(int? id)
        {
            if (id == null)
                return BadRequest();

            GameService service = CreateGameService();

            return Ok(service.GetGameByID(id.Value));
        }

        [Route("{id}/Visitors")]
        public IHttpActionResult GetVisitorsByGame(int? id)
        {
            if (id == null)
                return BadRequest();

            GameService service = CreateGameService();

            return Ok(service.GetGameVisitors(id.Value));
        }

        public IHttpActionResult Post(GameCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GameService service = CreateGameService();

            if (service.CreateGame(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Put(GameEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GameService service = CreateGameService();

            if (service.UpdateExistingGame(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            GameService service = CreateGameService();

            if (service.DeleteGame(id.Value))
                return Ok();

            return InternalServerError();
        }

        private GameService CreateGameService() => new GameService(Guid.Parse(User.Identity.GetUserId()), User.IsInRole("Admin"));
    }
}
