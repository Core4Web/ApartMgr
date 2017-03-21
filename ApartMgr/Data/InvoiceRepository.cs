using ApartMgr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.Data
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetInvoices();
    }

    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApartMgrContext _ctx;
        public InvoiceRepository(ApartMgrContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            return _ctx.Invoices
                .Include(i=>i.Period)
                .ToList();
        }
    }
}
