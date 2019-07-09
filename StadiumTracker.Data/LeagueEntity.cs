using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Data
{
    public class LeagueEntity
    {
        [Key]
        public int LeagueID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string LeagueName { get; set; }

        public virtual ICollection<TeamEntity> Teams { get; set; }
    }
}
