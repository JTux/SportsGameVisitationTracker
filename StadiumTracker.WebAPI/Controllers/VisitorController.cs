using Microsoft.AspNet.Identity;
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
    public class VisitorController : ApiController
    {
        public IHttpActionResult Get()
        {
            VisitorService service = CreateVisitorService();
            return Ok(service.GetAllVisitors());
        }

        public IHttpActionResult Get(int? id)
        {
            if (id == null)
                return BadRequest();

            VisitorService service = CreateVisitorService();

            return Ok(service.GetVisitorByID(id.Value));
        }

        public IHttpActionResult Post(VisitorCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VisitorService service = CreateVisitorService();

            if (service.CreateVisitor(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Put(VisitorEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VisitorService service = CreateVisitorService();

            if (service.UpdateExistingVisitor(model))
                return Ok();

            return InternalServerError();
        }

        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            VisitorService service = CreateVisitorService();

            if (service.DeleteVisitor(id.Value))
                return Ok();

            return InternalServerError();
        }

        private VisitorService CreateVisitorService() => new VisitorService(Guid.Parse(User.Identity.GetUserId()), User.IsInRole("Admin"));
    }
}
