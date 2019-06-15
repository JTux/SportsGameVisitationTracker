using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.TeamModels
{
    public class TeamListItem
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int LeagueID { get; set; }
        public string LeagueName { get; set; }
        public bool UserIsOwner { get; set; }
        public string ImageData { get; set; }
    }
}
