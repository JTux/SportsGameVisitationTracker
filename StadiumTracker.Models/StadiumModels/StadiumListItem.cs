﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.StadiumModels
{
    public class StadiumListItem
    {
        public int StadiumID { get; set; }
        public string StadiumName { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public bool UserIsOwner { get; set; }
    }
}
