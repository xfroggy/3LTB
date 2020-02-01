using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Models
{
    public class SequenceOpDate
    {
        public int SequenceSeqNum { get; set; }
        public Sequence Sequence { get; set; }

        public int OpDateID { get; set; }
        public OpDate OpDate { get; set; }


    }
}