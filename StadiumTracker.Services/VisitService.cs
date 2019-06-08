using StadiumTracker.Data;
using StadiumTracker.Models.VisitModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Services
{
    public class VisitService
    {
        private readonly Guid _userID;
        private readonly bool _userIsAdmin;

        public VisitService(Guid userID, bool userIsAdmin)
        {
            _userID = userID;
            _userIsAdmin = userIsAdmin;
        }

        public bool CreateVisit(VisitCreate model)
        {
            var entity = new VisitEntity
            {
                GameID = model.GameID,
                VisitorID = model.VisitorID,
                GotPin = model.GotPin,
                TookPhoto = model.TookPhoto,
                OwnerID = _userID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Visits.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VisitListItem> GetAllVisits()
        {
            using (var ctx = new ApplicationDbContext())
            {
                VisitorService visitorService = new VisitorService(_userID, _userIsAdmin);
                GameService gameService = new GameService(_userID, _userIsAdmin);

                var visits =
                    ctx.Visits
                    .Where(visit => visit.OwnerID == _userID)
                    .Select(
                        entity =>
                        new VisitListItem
                        {
                            VisitID = entity.VisitID,
                            GotPin = entity.GotPin,
                            TookPhoto = entity.TookPhoto,
                            Visitor = visitorService.GetVisitorByID(entity.VisitorID),
                            Game = gameService.GetGameByID(entity.GameID)
                        }
                    ).ToArray();

                return visits;
            }
        }

        public VisitDetail GetVisitByID(int visitID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Visits.FirstOrDefault(visit => visit.VisitID == visitID && visit.OwnerID == _userID);

                if (entity != null)
                {
                    VisitorService visitorService = new VisitorService(_userID, _userIsAdmin);
                    GameService gameService = new GameService(_userID, _userIsAdmin);

                    return new VisitDetail
                    {
                        VisitID = entity.VisitID,
                        GotPin = entity.GotPin,
                        TookPhoto = entity.TookPhoto,
                        Game = gameService.GetGameByID(entity.GameID),
                        Visitor = visitorService.GetVisitorByID(entity.VisitorID)
                    };
                }
                else
                    return null;
            }
        }

        public bool UpdateExistingVisit(VisitEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Visits.FirstOrDefault(visit => visit.VisitID == model.VisitID && visit.OwnerID == _userID);

                if (entity == null)
                    return false;

                entity.GotPin = model.GotPin;
                entity.TookPhoto = model.TookPhoto;
                entity.VisitorID = model.VisitorID;
                entity.GameID = model.GameID;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVisit(int visitID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Visits.FirstOrDefault(visit => visit.VisitID == visitID && (visit.OwnerID == _userID || _userIsAdmin));

                if (entity == null)
                    return false;

                ctx.Visits.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
