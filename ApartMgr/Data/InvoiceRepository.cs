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
        Invoice GetInvoice(int id);
    }

    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApartMgrContext _ctx;
        public InvoiceRepository(ApartMgrContext ctx)
        {
            _ctx = ctx;
        }

        public Invoice GetInvoice(int id)
        {
            return _ctx.Invoices
                .Include(i=>i.Period)
                .SingleOrDefault(x=>x.Id==id);
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            return _ctx.Invoices
                .Include(i=>i.Period)
                .ToList();
        }
    }
}
