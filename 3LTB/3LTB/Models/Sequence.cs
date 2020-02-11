using _3LTB.Helpers;
using CsvHelper.Configuration.Attributes;
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
        [Name("SeqNum")]
        public int SeqNum { get; set; }
        [Name("TTL")]
        public float TTL { get; set; }
        [Name("RIG")]
        public float RIG { get; set; }
        [Name("GTTL")]
        public float GTTL { get; set; }
        [Name("DaysOp")]
        public int DaysOp { get; set; }

        public IList<DutyPeriod> DutyPeriods { get; set; }
        public IList<SequenceOpDate> SequenceOpDates { get; set; }

    }
}
