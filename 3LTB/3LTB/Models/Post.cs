using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Models
{
    public class Post
    {
        public int ID { get; set; }
        public int UserID { get; set; } // Links IdentityUser with Post entity??
        public string DepartureCity { get; set; }
        public string Trade { get; set; }
        public string Title { get; set; }
        public int Flight { get; set; }
        public DateTime FlightDate { get; set; }
        public int Position { get; set; }
        public string Report { get; set; }
        public bool Lang { get; set; }
        public string ArrivalCity { get; set; }
        public bool RedFlag { get; set; }
    }
}
