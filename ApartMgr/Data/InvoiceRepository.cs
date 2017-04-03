using ApartMgr.Helpers;
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
        DbSet<Invoice> Table { get; }
        IEnumerable<Invoice> GetInvoices(InvoiceResourceParameters invoiceParameters);
        Invoice GetInvoice(int id);
        void Create(Invoice invoice);
        bool InvoiceExists(int id);
        bool Commit();
        void DeleteInvoice(Invoice invoice);
    }

    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApartMgrContext _ctx;
        public DbSet<Invoice> Table { get { return _ctx.Invoices; } }
        public InvoiceRepository(ApartMgrContext ctx)
        {
            _ctx = ctx;
        }

        public Invoice GetInvoice(int id)
        {
            return _ctx.Invoices
                .Include(i => i.Period)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Invoice> GetInvoices(InvoiceResourceParameters invoiceParameters)
        {
            var query = _ctx.Invoices.Include(i => i.Period).AsQueryable();
            if (invoiceParameters.Period!=null)
            {
                query = query.Where(x => x.PeriodId == invoiceParameters.Period);
            }
            if (!string.IsNullOrEmpty(invoiceParameters.SearchQuery))
            {
                var whereClause = invoiceParameters.SearchQuery.Trim().ToLowerInvariant();
                query = query.Where(x => x.Number.ToLowerInvariant().Contains(whereClause) ||
                    x.Account.ToLowerInvariant().Contains(whereClause));
            }
            return query.Skip(invoiceParameters.PageSize*(invoiceParameters.PageNumber-1))
                .Take(invoiceParameters.PageSize)
                .ToList();
        }

        public void Create(Invoice invoice)
        {
            _ctx.Invoices.Add(invoice);
        }

        public bool InvoiceExists(int id)
        {
            return _ctx.Invoices.SingleOrDefault(x => x.Id == id) != null;
        }

        public bool Commit()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void DeleteInvoice(Invoice invoice)
        {
            _ctx.Invoices.Remove(invoice);
        }
    }
}
