using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StadiumTracker.Models.GameModels;

namespace StadiumTracker.Models.VisitorModels
{
    public class VisitorDetail
    {
        public int VisitorID { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public int VisitCount { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<GameDetail> Games { get; set; }
    }
}
