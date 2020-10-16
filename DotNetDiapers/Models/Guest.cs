using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetDiapers.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }

        // reference to AspNetUser table
        [ForeignKey("UserId")]
        public  IdentityUser User { get; set; }

        //reference to child object
        public List<BabyPrediction> BabyPredictions { get; set; }

    }
}
