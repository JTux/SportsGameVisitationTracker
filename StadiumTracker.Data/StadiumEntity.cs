using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Data
{
    public class StadiumEntity
    {
        [Key]
        public int StadiumID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string ParkName { get; set; }

        [Required]
        public string CityName { get; set; }
    }
}
