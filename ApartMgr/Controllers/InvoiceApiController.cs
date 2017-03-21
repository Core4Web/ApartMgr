using ApartMgr.Data;
using ApartMgr.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.Controllers
{
    [Route("api/invoices")]
    public class InvoiceApiController: Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceApiController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet()]
        public IActionResult GetInvoices()
        {
            var entity = _invoiceRepository.GetInvoices();
            var model = Mapper.Map<IEnumerable<InvoiceList>>(entity);

            return new JsonResult(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetInvoice(int id)
        {
            var entity = _invoiceRepository.GetInvoice(id);
            var model = Mapper.Map<InvoiceList>(entity);
            return new JsonResult(model);
        }
    }
}
