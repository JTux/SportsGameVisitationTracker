using StadiumTracker.Data;
using StadiumTracker.Models.LeagueModels;
using StadiumTracker.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Services
{
    public class LeagueService
    {
        private readonly Guid _userID;
        private readonly bool _userIsAdmin;

        private readonly Guid _publicGuid = new Guid("00000000-0000-0000-0000-000000000000");

        public LeagueService(Guid userID, bool userIsAdmin)
        {
            _userID = userID;
            _userIsAdmin = userIsAdmin;
        }

        public bool CreateLeague(LeagueCreate model)
        {
            var entity = new LeagueEntity
            {
                LeagueName = model.LeagueName,
                OwnerID = _userID
            };

            int changeCount = 1;

            if (model.Teams != null)
            {
                entity.Teams = new List<TeamEntity>();
                foreach (LeagueTeamCreate team in model.Teams)
                {
                    entity.Teams.Add(
                        new TeamEntity
                        {
                            OwnerID = _userID,
                            TeamName = team.TeamName,
                            ImageData = team.ImageData
                        });
                }
                changeCount += entity.Teams.Count;
            }

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Leagues.Add(entity);
                return ctx.SaveChanges() == changeCount;
            }
        }

        public IEnumerable<LeagueListItem> GetAllLeagues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var leagues =
                    ctx.Leagues
                    .Where(league => league.OwnerID == _userID || league.OwnerID == _publicGuid)
                    .Select(
                        entity =>
                        new LeagueListItem
                        {
                            LeagueID = entity.LeagueID,
                            UserIsOwner = entity.OwnerID == _userID,
                            LeagueName = entity.LeagueName
                        }
                    ).OrderBy(league => league.LeagueName).ToArray();

                var orderedLeagues = leagues.OrderBy(league => league.LeagueName).ToArray();

                return orderedLeagues;
            }
        }

        public LeagueDetail GetLeagueByID(int leagueID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Leagues
                    .FirstOrDefault(league => league.LeagueID == leagueID && (league.OwnerID == _userID || league.OwnerID == _publicGuid));

                if (entity != null)
                {
                    var memberTeams =
                        ctx.Teams
                            .Where(team => team.LeagueID == entity.LeagueID)
                            .Select(team => new TeamDetail
                            {
                                LeagueID = team.LeagueID,
                                LeagueName = team.League.LeagueName,
                                TeamID = team.TeamID,
                                TeamName = team.TeamName,
                                ImageData = team.ImageData,
                                UserIsOwner = team.OwnerID == _userID
                            }).OrderBy(team => team.TeamName).ToList();

                    return new LeagueDetail
                    {
                        LeagueID = entity.LeagueID,
                        LeagueName = entity.LeagueName,
                        UserIsOwner = entity.OwnerID == _userID,
                        MemberTeams = memberTeams
                    };
                }
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

                entity.LeagueName = model.LeagueName;

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
