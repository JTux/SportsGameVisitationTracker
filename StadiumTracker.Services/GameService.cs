using StadiumTracker.Data;
using StadiumTracker.Models.GameModels;
using StadiumTracker.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Services
{
    public class GameService
    {
        private readonly Guid _userID;
        private readonly bool _userIsAdmin;

        public GameService(Guid userID, bool userIsAdmin)
        {
            _userID = userID;
            _userIsAdmin = userIsAdmin;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity = new GameEntity
            {
                DateOfGame = model.DateOfGame,
                StadiumID = model.StadiumID,
                HomeTeamID = model.HomeTeamID,
                AwayTeamID = model.AwayTeamID,
                HomeTeamWon = model.HomeTeamWon,
                OwnerID = _userID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetAllGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games =
                    ctx.Games
                    .Select(
                        entity =>
                        new GameListItem
                        {
                            GameID = entity.GameID,
                            DateOfGame = entity.DateOfGame,
                            HomeTeamWon = entity.HomeTeamWon,
                            StadiumID = entity.StadiumID,
                            StadiumName = entity.Stadium.StadiumName,
                            HomeTeamID = entity.HomeTeamID,
                            HomeTeamName = entity.HomeTeam.TeamName,
                            AwayTeamID = entity.AwayTeamID,
                            AwayTeamName = entity.AwayTeam.TeamName,
                            UserIsOwner = entity.OwnerID == _userID,
                        }
                    ).ToArray();

                return games;
            }
        }

        public GameDetail GetGameByID(int gameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.FirstOrDefault(game => game.GameID == gameID);

                if (entity != null)
                {
                    TeamService teamService = new TeamService(_userID, _userIsAdmin);
                    StadiumService stadiumService = new StadiumService(_userID, _userIsAdmin);

                    return new GameDetail
                    {
                        GameID = entity.GameID,
                        DateOfGame = entity.DateOfGame,
                        HomeTeamWon = entity.HomeTeamWon,
                        Stadium = stadiumService.GetStadiumByID(entity.StadiumID),
                        HomeTeam = teamService.GetTeamByID(entity.HomeTeamID),
                        AwayTeam = teamService.GetTeamByID(entity.AwayTeamID),
                        UserIsOwner = entity.OwnerID == _userID
                    };
                } 
                else
                    return null;
            }
        }

        public bool UpdateExistingGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.FirstOrDefault(game => game.GameID == model.GameID && game.OwnerID == _userID);

                if (entity == null)
                    return false;

                entity.DateOfGame = model.DateOfGame;
                entity.HomeTeamID = model.HomeTeamID;
                entity.AwayTeamID = model.AwayTeamID;
                entity.StadiumID = model.StadiumID;
                entity.HomeTeamWon = model.HomeTeamWon;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int gameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.FirstOrDefault(game => game.GameID == gameID && (game.OwnerID == _userID || _userIsAdmin));

                if (entity == null)
                    return false;

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
