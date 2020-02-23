using _3LTB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace _3LTB.Models

{    public class Base
    {
        [Key]
        public int ID { get; set; }
        public string BaseName { get; set; }
        public IList<Sequence> Sequences { get; set; }


    }
}
