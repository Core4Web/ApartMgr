using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.ViewModels
{
    public class InvoiceUpdate
    {
        [StringLength(256)]
        public string Number { get; set; }
        [StringLength(256)]
        public string Account { get; set; }
        [Required, Range(1980, 2100)]
        public int Year { get; set; }
        [Required]
        public int PeriodId { get; set; }
    }
}
