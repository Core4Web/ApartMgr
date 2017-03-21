using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.ViewModels
{
    public class InvoiceList
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Account { get; set; }
        public string PeriodName{ get; set; }
        public int Year { get; set; }
    }
}
