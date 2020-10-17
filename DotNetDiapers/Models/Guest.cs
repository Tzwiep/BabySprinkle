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

        [Required(ErrorMessage = "Please enter your name to RSVP")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address to RSVP")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Create a fun username to participate in the shower games")]
        [MaxLength(20)]
        [Display(Name ="Username")]
        public string Username { get; set; }

        //reference to child object
        public List<BabyPrediction> BabyPredictions { get; set; }

    }
}
