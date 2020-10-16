﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetDiapers.Models
{
    public class BabyPrediction
    {
        public int Id { get; set; }
        [Required]

        public DateTime Due_Date { get; set; } 

        public double Birth_Weight { get; set; }

        public string Baby_Name { get;  set; }

        public string GuestId { get; set; }

        // add reference to parent object
        public Guest Guest { get; set; }
    }
}