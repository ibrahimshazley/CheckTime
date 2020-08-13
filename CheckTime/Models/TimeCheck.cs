using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckTime.Models
{
    public class TimeCheck
    {
        public Guid id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


    }
}
