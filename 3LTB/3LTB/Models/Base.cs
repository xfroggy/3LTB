using _3LTB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Models
{
    public class Base
    {
        public int ID { get; set; }
        public int BaseName { get; set; }
        public IList<Sequence> Sequences { get; set; }
  
    }
}
