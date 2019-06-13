﻿using StadiumTracker.Data;
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
                    .Where(league => league.OwnerID == _userID || league.OwnerID == _publicGuid)
                    .Select(
                        entity =>
                        new LeagueListItem
                        {
                            LeagueID = entity.LeagueID,
                            UserIsOwner = entity.OwnerID == _userID,
                            LeagueName = entity.LeagueName
                        }
                    ).ToArray();

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
                    return new LeagueDetail
                    {
                        LeagueID = entity.LeagueID,
                        LeagueName = entity.LeagueName,
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
