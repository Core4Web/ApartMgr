using ApartMgr.Data;
using ApartMgr.Models;
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
            try
            {
                var entity = _invoiceRepository.GetInvoices();
                var model = Mapper.Map<IEnumerable<InvoiceList>>(entity);
                return Ok(model);
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to get invoices");
            }
        }

        [HttpGet("{id}", Name = "GetInvoice")]
        public IActionResult GetInvoice(int id)
        {
            try
            {
                var entity = _invoiceRepository.GetInvoice(id);
                if (entity == null)
                {
                    return NotFound();
                }
                var model = Mapper.Map<InvoiceList>(entity);
                return Ok(model);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Failed to get invoice {id}");
            }
        }

        [HttpPost]
        public IActionResult CreateInvoice([FromBody] InvoiceCreate model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var entity = Mapper.Map<Invoice>(model);
                _invoiceRepository.Create(entity);
                if (!_invoiceRepository.Commit())
                {
                    return StatusCode(500, "Failed to create new invoice");
                }
                var returnModel = Mapper.Map<InvoiceList>(entity);
                return CreatedAtRoute("GetInvoice", new { id = entity.Id }, returnModel);
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to create new invoice");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            if(!_invoiceRepository.InvoiceExists(id))
            {
                return NotFound();
            }
            var entity = _invoiceRepository.GetInvoice(id);
            if (entity == null)
            {
                return NotFound();
            }
            _invoiceRepository.DeleteInvoice(entity);
            if(!_invoiceRepository.Commit())
            {
                return StatusCode(500, $"Failed to delete invoice {id}");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult InvoicePut(int id, [FromBody] InvoiceUpdate model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var entity = _invoiceRepository.GetInvoice(id);
                if (entity == null)
                {
                    return NotFound();
                }
                Mapper.Map(model, entity);
                if (!_invoiceRepository.Commit())
                {
                    return StatusCode(500, $"Failed to update invoice {id}");
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, $"Failed to update invoice {id}");
            }
        }
    }
}
