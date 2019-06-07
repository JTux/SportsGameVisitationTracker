using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Data
{
    public class TeamEntity
    {
        [Key]
        public int TeamID { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [ForeignKey(nameof(League))]
        public int LeagueID { get; set; }
        public virtual LeagueEntity League { get; set; }
    }
}
