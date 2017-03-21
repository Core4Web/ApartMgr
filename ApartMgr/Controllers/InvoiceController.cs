using ApartMgr.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.Controllers
{
    [Route("api/invoices")]
    public class InvoiceController: Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet()]
        public IActionResult GetInvoices()
        {
            var entity = _invoiceRepository.GetInvoices();
            return new JsonResult(entity);
        }
    }
}
