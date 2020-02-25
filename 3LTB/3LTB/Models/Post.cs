using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string UserID { get; set; } // Links IdentityUser with Post entry, but not as a foreign key.
        public string DepartureCity { get; set; }
        public string Trade { get; set; }
        public string Title { get; set; }
        public int Flight { get; set; }
        //Had to define DataFormatString here so that it displays properly??
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FlightDate { get; set; }
        public int Position { get; set; }
        public string Report { get; set; }
        public bool Lang { get; set; }
        public string ArrivalCity { get; set; }
        public bool RedFlag { get; set; }
    }
}
