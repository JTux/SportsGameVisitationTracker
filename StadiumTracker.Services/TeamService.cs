using StadiumTracker.Data;
using StadiumTracker.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Services
{
    public class TeamService
    {
        private readonly Guid _userID;
        private readonly bool _userIsAdmin;

        public TeamService(Guid userID, bool userIsAdmin)
        {
            _userID = userID;
            _userIsAdmin = userIsAdmin;
        }

        public bool CreateTeam(TeamCreate model)
        {
            var entity = new TeamEntity
            {
                TeamName = model.TeamName,
                LeagueID = model.LeagueID,
                OwnerID = _userID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetAllTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var teams =
                    ctx.Teams
                    .Select(
                        entity => new TeamListItem
                        {
                            TeamID = entity.TeamID,
                            TeamName = entity.TeamName,
                            LeagueName = entity.League.Name,
                            UserIsOwner = entity.OwnerID == _userID
                        }
                    ).ToArray();

                return teams;
            }
        }

        public TeamDetail GetTeamByID(int teamID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teams.FirstOrDefault(team => team.TeamID == teamID);

                if (entity != null)
                    return new TeamDetail
                    {
                        TeamID = entity.TeamID,
                        TeamName = entity.TeamName,
                        UserIsOwner = entity.OwnerID == _userID,
                        LeagueID = entity.LeagueID,
                        LeagueName = entity.League.Name
                    };
                else
                    return null;
            }
        }

        public bool UpdateExistingTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teams.FirstOrDefault(team => team.TeamID == model.TeamID && team.OwnerID == _userID);

                if (entity == null)
                    return false;

                entity.TeamName = model.TeamName;
                entity.LeagueID = model.LeagueID;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam (int teamID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teams.FirstOrDefault(team => team.TeamID == teamID && (team.OwnerID == _userID || _userIsAdmin));

                if (entity == null)
                    return false;

                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
