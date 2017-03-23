using ApartMgr.Data;
using ApartMgr.Models;
using ApartMgr.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartMgr.Controllers
{
    [Route("api/invoiceCollections")]
    public class InvoiceCollectionsApiController: Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceCollectionsApiController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost]
        public IActionResult CreateInvoiceCollection([FromBody] IEnumerable<InvoiceCreate> model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var entities = Mapper.Map<IEnumerable<Invoice>>(model);
            foreach (var item in entities)
            {
                _invoiceRepository.Create(item);
            }
            if (!_invoiceRepository.Commit())
            {
                return StatusCode(500, "Failed create new invoice");
            }
            return Ok();
        }

    }
}
