using ApartMgr.Data;
using ApartMgr.Helpers;
using ApartMgr.Models;
using ApartMgr.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<InvoiceApiController> _logger;

        public InvoiceApiController(IInvoiceRepository invoiceRepository, ILogger<InvoiceApiController> logger)
        {
            _invoiceRepository = invoiceRepository;
            _logger = logger;
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
                if(!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }
                var entity = Mapper.Map<Invoice>(model);
                _invoiceRepository.Create(entity);
                if (!_invoiceRepository.Commit())
                {
                    throw new Exception();
                }
                var returnModel = Mapper.Map<InvoiceList>(entity);
                return CreatedAtRoute("GetInvoice", new { id = entity.Id }, returnModel);
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to create new invoice");
            }
        }

        [HttpPost("{id}")]
        public IActionResult BlockCreation(int id)
        {
            if(_invoiceRepository.InvoiceExists(id))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            try
            {
                if (!_invoiceRepository.InvoiceExists(id))
                {
                    return NotFound();
                }
                var entity = _invoiceRepository.GetInvoice(id);
                if (entity == null)
                {
                    return NotFound();
                }
                _invoiceRepository.DeleteInvoice(entity);
                if (!_invoiceRepository.Commit())
                {
                    throw new Exception();
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, $"Failed to delete invoice {id}");
            }
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
                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }
                var entity = _invoiceRepository.GetInvoice(id);
                if (entity == null)
                {
                    entity = Mapper.Map<Invoice>(model);
                    _invoiceRepository.Create(entity);
                    if (!_invoiceRepository.Commit())
                    {
                        throw new Exception();
                    }
                    var returnModel = Mapper.Map<InvoiceList>(entity);
                    return CreatedAtRoute("GetInvoice", new { id = entity.Id }, returnModel);
                }
                Mapper.Map(model, entity);
                if (!_invoiceRepository.Commit())
                {
                    throw new Exception();
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, $"Failed to update invoice {id}");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult PatchInvoice(int id, [FromBody] JsonPatchDocument<InvoiceUpdate> patchModel)
        {
            try
            {
                if (patchModel == null)
                {
                    return BadRequest();
                }
                var entity = _invoiceRepository.GetInvoice(id);
                if (entity == null)
                {
                    return NotFound();
                }
                var model = Mapper.Map<InvoiceUpdate>(entity);
                patchModel.ApplyTo(model, ModelState);
                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }
                Mapper.Map(model, entity);
                if (!_invoiceRepository.Commit())
                {
                    throw new Exception();
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, $"Failed to patch invoice {id}");
            }
        }

    }
}
