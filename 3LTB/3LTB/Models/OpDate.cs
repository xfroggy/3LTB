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

        private static int nextId = 1;
        //public int[] PossibleDates = { 31, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
        //    11, 12, 13, 14, 15, 16, 17,18,19,20,
        //    21,22,23,24,25,26,27,28,29,30,31,1};



        public int DateOp { get; set; }
        public IList<SequenceOpDate> SequenceOpDates { get; set; } = new List<SequenceOpDate>();




    }
}
