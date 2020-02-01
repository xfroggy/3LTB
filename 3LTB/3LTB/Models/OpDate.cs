using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Models
{
    public class OpDate
    {

        public int ID { get; set; }
        public int DateOp { get; set; }
        public IList<SequenceOpDate> SequenceOpDates { get; set; } = new List<SequenceOpDate>();


    }
}
