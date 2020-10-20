using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DotNetDiapers.Models
{
    public class BabyPrediction
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Guess what day the baby will be born")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime Due_Date { get; set; }

        [Required(ErrorMessage = "Guess how much the baby will weigh")]
        [Display(Name = "Birth Weight")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0} lbs")]
        [Range(5,15, ErrorMessage="Yikes! Hopefully weight will be between 4 and 12 pounds")]
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
