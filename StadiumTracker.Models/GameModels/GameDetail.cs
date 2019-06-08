using StadiumTracker.Data;
using StadiumTracker.Models.StadiumModels;
using StadiumTracker.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.GameModels
{
    public class GameDetail
    {
        public int GameID { get; set; }

        public DateTimeOffset DateOfGame { get; set; }

        public StadiumDetail Stadium { get; set; }

        public TeamDetail HomeTeam { get; set; }

        public TeamDetail AwayTeam { get; set; }

        public bool HomeTeamWon { get; set; }
        public bool UserIsOwner { get; set; }
    }
}
