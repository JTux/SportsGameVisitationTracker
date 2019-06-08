using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.GameModels
{
    public class GameCreate
    {
        [Required]
        public DateTimeOffset DateOfGame { get; set; }

        [Required]
        public int StadiumID { get; set; }

        [Required]
        public int HomeTeamID { get; set; }

        [Required]
        public int AwayTeamID { get; set; }

        [Required]
        public bool HomeTeamWon { get; set; }
    }
}
