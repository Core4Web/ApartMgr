using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.ViewModels
{
    public class InvoiceUpdate
    {
        public string Number { get; set; }
        public string Account { get; set; }
        public int Year { get; set; }
        public int PeriodId { get; set; }
    }
}
