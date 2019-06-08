using StadiumTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.StadiumModels
{
    public class StadiumEdit
    {
        [Required]
        public int StadiumID { get; set; }

        [Required]
        public string StadiumName { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public StateEnum StateName { get; set; }
    }
}
