using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.GameModels
{
    public class GameListItem
    {
        public int GameID { get; set; }

        public DateTimeOffset DateOfGame { get; set; }

        public int StadiumID { get; set; }
        public string StadiumName { get; set; }

        public int HomeTeamID { get; set; }
        public string HomeTeamName { get; set; }

        public int AwayTeamID { get; set; }
        public string AwayTeamName { get; set; }

        public bool HomeTeamWon { get; set; }
        public bool UserIsOwner { get; set; }
    }
}
