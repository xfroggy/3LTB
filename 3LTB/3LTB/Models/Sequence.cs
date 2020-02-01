using _3LTB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Models
{
    public class Sequence
    {
        public Base Base { get; set; }
        public int BaseID { get; set; }
        [Key]
        public int SeqNum { get; set; }
        public float TTL { get; set; }
        public float RIG { get; set; }
        public float GTTL { get; set; }
        public int DaysOp { get; set; }

        public IList<DutyPeriod> DutyPeriods { get; set; }
        public IList<SequenceOpDate> SequenceOpDates { get; set; }

    }
}
