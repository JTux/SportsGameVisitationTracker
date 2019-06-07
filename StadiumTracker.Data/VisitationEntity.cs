using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Data
{
    public class VisitationEntity
    {
        [Key]
        public int VisitationID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public bool GotPin { get; set; }

        [Required]
        public bool TookPhoto { get; set; }

        [ForeignKey(nameof(Visitor))]
        public int VisitorID { get; set; }
        public virtual VisitorEntity Visitor { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameID { get; set; }
        public virtual GameEntity Game { get; set; }
    }
}
