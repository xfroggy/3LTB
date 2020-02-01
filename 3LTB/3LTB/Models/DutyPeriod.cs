using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Models
{
    public class DutyPeriod
    {
        public Sequence Sequence { get; set; }
        public int SequenceSeqNum { get; set; }
        public int ID { get; set; }
        public int DPnum { get; set; }
        public string RPTdayNum { get; set; }
        public string RPTdepLCL { get; set; }
        public string RPTdepHBT { get; set; }
        public string RLSarrLCL { get; set; }
        public string RLSarrHBT { get; set; }
        public float DPblock { get; set; }

    }
}


