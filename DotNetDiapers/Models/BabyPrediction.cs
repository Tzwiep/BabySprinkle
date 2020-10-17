using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetDiapers.Models
{
    public class BabyPrediction
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Guess what day the baby will be born")]
        [Display(Name = "Guess The Birthdate")]
        public DateTime Due_Date { get; set; }

        [Display(Name = "Birth Weight")]
        public double Birth_Weight { get; set; }

        [Display(Name = "Gender")]
        public string Baby_Gender { get; set; }

        [Display(Name="Baby Name")]
        [MaxLength(20)]
        public string Baby_Name { get;  set; }

        [Display(Name ="Guest")]
        public int GuestId { get; set; }

        // reference to parent object 
        public Guest Guest { get; set; }
    }
}
