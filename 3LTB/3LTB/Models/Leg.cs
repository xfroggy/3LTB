using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Models
{
    public class Leg
    {
        public DutyPeriod DutyPeriod { get; set; }
        public int DutyPeriodID { get; set; }
        public int ID { get; set; }
        private static int nextId = 1;
        public int DPnum { get; set; }
        public int DayNumStart { get; set; }
        public int DayNumEnd { get; set; }
        public string EQP { get; set; }
        public int FLTnum { get; set; }
        public string DEPcity { get; set; }
        public string DEPlcl { get; set; }
        public string DEPhbt { get; set; }
        public string ARRcity { get; set; }
        public string ARRlcl { get; set; }
        public string ARRhbt { get; set; }
        public float LEGblock { get; set; }
        public Leg()
        {
            ID = nextId;
            nextId++;
        }
    }
}
