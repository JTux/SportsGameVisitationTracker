﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumTracker.Models.LeagueModels
{
    public class LeagueEdit
    {
        [Required]
        public int LeagueID { get; set; }

        [Required]
        public string LeagueName { get; set; }
    }
}
