using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Account { get; set; }
        public int PeriodId { get; set; }
        public virtual Period Period { get; set; }
        public int Year { get; set; }
    }
}
