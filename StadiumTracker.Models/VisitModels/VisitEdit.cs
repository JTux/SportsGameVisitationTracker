using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.VisitModels
{
    public class VisitEdit
    {
        [Required]
        public int VisitID { get; set; }

        [Required]
        public bool GotPin { get; set; }

        [Required]
        public bool TookPhoto { get; set; }

        [Required]
        public int VisitorID { get; set; }

        [Required]
        public int GameID { get; set; }
    }
}
