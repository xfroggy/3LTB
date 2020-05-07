using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Models
{
    public class OpDate
    {
        [Key]
        public int ID { get; set; }               
        public int DateOp { get; set; }
        public IList<SequenceOpDate> SequenceOpDates { get; set; } 




    }
}
