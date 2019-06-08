using Microsoft.AspNet.Identity;
using StadiumTracker.Models.StadiumModels;
using StadiumTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StadiumTracker.WebAPI.Controllers
{
    public class StadiumController : ApiController
    {
        public IHttpActionResult Get()
        {
            StadiumService service = CreateStadiumService();
            return Ok(service.GetAllStadiums());
        }

        public IHttpActionResult Get(int? id)
        {
            if (id == null)
                return BadRequest();

            StadiumService service = CreateStadiumService();

            return Ok(service.GetStadiumByID(id.Value));
        }

        public IHttpActionResult Post(StadiumCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StadiumService service = CreateStadiumService();

            if (service.CreateStadium(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Put(StadiumEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StadiumService service = CreateStadiumService();

            if (service.UpdateExistingStadium(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            StadiumService service = CreateStadiumService();

            if (service.DeleteStadium(id.Value))
                return Ok();

            return InternalServerError();
        }

        private StadiumService CreateStadiumService() => new StadiumService(Guid.Parse(User.Identity.GetUserId()), User.IsInRole("Admin"));
    }
}
