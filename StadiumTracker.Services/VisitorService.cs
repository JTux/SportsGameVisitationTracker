using StadiumTracker.Data;
using StadiumTracker.Models.VisitorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Services
{
    public class VisitorService
    {
        private readonly Guid _userID;
        private readonly bool _userIsAdmin;

        public VisitorService(Guid userID, bool userIsAdmin)
        {
            _userID = userID;
            _userIsAdmin = userIsAdmin;
        }

        public bool CreateVisitor(VisitorCreate model)
        {
            var entity = new VisitorEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                OwnerID = _userID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Visitors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VisitorListItem> GetAllVisitors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var visitors =
                    ctx.Visitors
                    .Where(visitor => visitor.OwnerID == _userID)
                    .Select(
                        entity =>
                        new VisitorListItem
                        {
                            VisitorID = entity.VisitorID,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            VisitCount = ctx.Visits.Where(visit => visit.VisitorID == entity.VisitorID).Count()
                        }
                    ).ToArray();

                var orderedVisitors = visitors.OrderBy(visitor => visitor.FullName);

                return orderedVisitors;
            }
        }

        public VisitorDetail GetVisitorByID(int visitorID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Visitors.FirstOrDefault(visitor => visitor.VisitorID == visitorID && visitor.OwnerID == _userID);

                if (entity != null)
                {
                    return new VisitorDetail
                    {
                        VisitorID = entity.VisitorID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        VisitCount = ctx.Visits.Where(visit => visit.VisitorID == entity.VisitorID).Count()
                    };
                }
                else
                    return null;
            }
        }

        public bool UpdateExistingVisitor(VisitorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Visitors.FirstOrDefault(visitor => visitor.VisitorID == model.VisitorID && visitor.OwnerID == _userID);

                if (entity == null)
                    return false;

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVisitor(int visitorID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Visitors.FirstOrDefault(visitor => visitor.VisitorID == visitorID && (visitor.OwnerID == _userID || _userIsAdmin));

                if (entity == null)
                    return false;

                ctx.Visitors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
