using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.ViewModels
{
    public class CreatePostViewModel
    {
        public string UserID { get; set; } // Links IdentityUser with Post entry. Filled in with id of logged-in user.
        [Display(Name = "Departure City")]
        public string DepartureCity { get; set; }
        public string Trade { get; set; }
        [Required]
        public string Title { get; set; }
        public int Flight { get; set; }
        [Required]
        [Display(Name = "Flight Date")]
        [DataType(DataType.Date)]
        public DateTime FlightDate { get; set; }
        public int Position { get; set; }
        [Required]
        public string Report { get; set; }
        [Required]
        public bool Lang { get; set; }
        [Display(Name = "Arrival City")]
        public string ArrivalCity { get; set; }
        [Required]
        [Display(Name = "Red Flag")]
        public bool RedFlag { get; set; }
    }
}
