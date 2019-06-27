using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.GameModels
{
    public class GameVisitor
    {
        public int VisitorID { get; set; }
        public bool TookPhoto { get; set; }
        public bool GotPin { get; set; }
    }
}
