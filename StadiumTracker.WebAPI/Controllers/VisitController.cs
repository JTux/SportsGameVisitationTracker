using Microsoft.AspNet.Identity;
using StadiumTracker.Models.VisitModels;
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
    public class VisitController : ApiController
    {
        public IHttpActionResult Get()
        {
            VisitService service = CreateVisitService();
            return Ok(service.GetAllVisits());
        }

        public IHttpActionResult Get(int? id)
        {
            if (id == null)
                return BadRequest();

            VisitService service = CreateVisitService();

            return Ok(service.GetVisitByID(id.Value));
        }

        public IHttpActionResult Post(VisitCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VisitService service = CreateVisitService();

            if (service.CreateVisit(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Put(VisitEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VisitService service = CreateVisitService();

            if (service.UpdateExistingVisit(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            VisitService service = CreateVisitService();

            if (service.DeleteVisit(id.Value))
                return Ok();

            return InternalServerError();
        }

        private VisitService CreateVisitService() => new VisitService(Guid.Parse(User.Identity.GetUserId()), User.IsInRole("Admin"));
    }
}
