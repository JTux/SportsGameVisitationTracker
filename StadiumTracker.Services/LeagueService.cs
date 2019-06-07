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

        public LeagueService(Guid userID)
        {
            _userID = userID;
        }

        //-- Create
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

        //-- Get all Leagues
        
        //-- Get my leagues

        //-- Get League by ID

        //-- Update League

        //-- Delete League
    }
}
