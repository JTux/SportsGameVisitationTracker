using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Data
{
    public class GameEntity
    {
        [Key]
        public int GameID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public DateTime DateOfGame { get; set; }

        [ForeignKey(nameof(Stadium))]
        public int StadiumID { get; set; }
        public virtual StadiumEntity Stadium { get; set; }

        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamID { get; set; }
        public virtual TeamEntity HomeTeam { get; set; }

        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamID { get; set; }
        public virtual TeamEntity AwayTeam { get; set; }
    }
}
