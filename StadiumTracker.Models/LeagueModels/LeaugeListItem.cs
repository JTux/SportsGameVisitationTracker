using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.LeagueModels
{
    public class LeagueListItem
    {
        public int LeagueID { get; set; }

        public string Name { get; set; }

        public bool IsUserOwned { get; set; }
    }
}
