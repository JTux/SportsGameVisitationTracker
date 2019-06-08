using StadiumTracker.Data;
using StadiumTracker.Models.LeagueModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Services
{
    public class LeagueService
    {
        private Guid _userID;
        private bool _userIsAdmin;

        public LeagueService(Guid userID, bool userIsAdmin)
        {
            _userID = userID;
            _userIsAdmin = userIsAdmin;
        }

        public bool CreateLeague(LeagueCreate model)
        {
            var entity = new LeagueEntity
            {
                Name = model.Name,
                OwnerID = _userID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Leagues.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LeagueListItem> GetAllLeagues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var leagues =
                    ctx.Leagues
                    .Select(
                        entity =>
                        new LeagueListItem
                        {
                            LeagueID = entity.LeagueID,
                            UserIsOwner = entity.OwnerID == _userID,
                            Name = entity.Name
                        }
                    ).ToArray();

                return leagues;
            }
        }

        public LeagueDetail GetLeagueByID(int leagueID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Leagues.FirstOrDefault(league => league.LeagueID == leagueID);

                if (entity != null)
                    return new LeagueDetail
                    {
                        LeagueID = entity.LeagueID,
                        Name = entity.Name,
                        UserIsOwner = entity.OwnerID == _userID
                    };
                else
                    return null;
            }
        }

        public bool UpdateExistingLeague(LeagueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Leagues.FirstOrDefault(league => league.LeagueID == model.LeagueID && league.OwnerID == _userID);

                if (entity == null)
                    return false;

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLeague(int leagueID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Leagues.FirstOrDefault(league => league.LeagueID == leagueID && (league.OwnerID == _userID || _userIsAdmin));

                if (entity == null)
                    return false;

                ctx.Leagues.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
