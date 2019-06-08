using StadiumTracker.Models.GameModels;
using StadiumTracker.Models.VisitorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.VisitModels
{
    public class VisitListItem
    {
        public int VisitID { get; set; }

        public bool GotPin { get; set; }

        public bool TookPhoto { get; set; }

        public VisitorDetail Visitor { get; set; }

        public GameDetail Game { get; set; }
    }
}
