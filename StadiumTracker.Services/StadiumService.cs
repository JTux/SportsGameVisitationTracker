using StadiumTracker.Data;
using StadiumTracker.Models.StadiumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Services
{
    public class StadiumService
    {
        private Guid _userID;
        private bool _userIsAdmin;

        public StadiumService(Guid userID, bool userIsAdmin)
        {
            _userID = userID;
            _userIsAdmin = userIsAdmin;
        }

        public bool CreateStadium(StadiumCreate model)
        {
            var entity = new StadiumEntity
            {
                StadiumName = model.StadiumName,
                CityName = model.CityName,
                StateName = model.StateName,
                OwnerID = _userID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stadiums.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StadiumListItem> GetAllStadiums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var stadiums =
                    ctx.Stadiums
                    .Select(
                        entity => new StadiumListItem
                        {
                            StadiumID = entity.StadiumID,
                            StadiumName = entity.StadiumName,
                            CityName = entity.CityName,
                            StateName = entity.StateName,
                            UserIsOwner = entity.OwnerID == _userID
                        }
                    ).ToArray();

                return stadiums;
            }
        }

        public StadiumDetail GetStadiumByID(int stadiumID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stadiums.FirstOrDefault(stadium => stadium.StadiumID == stadiumID);

                if (entity != null)
                    return new StadiumDetail
                    {
                        StadiumID = entity.StadiumID,
                        StadiumName = entity.StadiumName,
                        CityName = entity.CityName,
                        StateName = entity.StateName,
                        UserIsOwner = entity.OwnerID == _userID
                    };
                else
                    return null;
            }
        }

        public bool UpdateExistingStadium(StadiumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stadiums.FirstOrDefault(stadium => stadium.StadiumID == model.StadiumID && stadium.OwnerID == _userID);

                if (entity == null)
                    return false;

                entity.StadiumName = model.StadiumName;
                entity.CityName = model.CityName;
                entity.StateName = model.StateName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStadium(int stadiumID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stadiums.FirstOrDefault(stadium => stadium.StadiumID == stadiumID && (stadium.OwnerID == _userID || _userIsAdmin));

                if (entity == null)
                    return false;

                ctx.Stadiums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
