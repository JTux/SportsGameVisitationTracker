using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.TeamModels
{
    public class TeamEdit
    {
        [Required]
        public int TeamID { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public int LeagueID { get; set; }
    }
}
