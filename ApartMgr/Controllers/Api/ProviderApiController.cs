using ApartMgr.Data;
using ApartMgr.Helpers;
using ApartMgr.Models;
using ApartMgr.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.Controllers.Api
{
    [Route("api/providers")]
    public class ProviderApiController: Controller
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderApiController(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        [HttpGet()]
        public IActionResult GetProviders()
        {
            try
            {
                var entity = _providerRepository.GetProviders();
                var model = Mapper.Map<IEnumerable<ProviderDetail>>(entity);
                return Ok(model);
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to get providers");
            }
        }

        [HttpGet("{id}", Name = "GetProvider")]
        public IActionResult GetProvider(int id)
        {
            try
            {
                var entity = _providerRepository.GetProvider(id);
                if (entity == null)
                {
                    return NotFound();
                }
                var model = Mapper.Map<ProviderDetail>(entity);
                return Ok(model);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Failed to get provider {id}");
            }
        }

        [HttpPost]
        public IActionResult CreateProvider([FromBody] ProviderCreate model)
        {
            try
            {
                if (model==null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }
                var entity = Mapper.Map<Provider>(model);
                _providerRepository.Create(entity);
                if (!_providerRepository.Commit())
                {
                    throw new Exception();
                }
                var returnModel = Mapper.Map<ProviderDetail>(entity);
                return CreatedAtRoute("GetProvider", new { id = entity.Id }, returnModel);
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to create new provider");
            }
        }
        [HttpPost("{id}")]
        public IActionResult BlockCreation(int id)
        {
            if (_providerRepository.ProviderExists(id))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProvider(int id)
        {
            try
            {
                if (!_providerRepository.ProviderExists(id))
                {
                    return NotFound();
                }
                var entity = _providerRepository.GetProvider(id);
                if (entity == null)
                {
                    return NotFound();
                }
                _providerRepository.Delete(entity);
                if (!_providerRepository.Commit())
                {
                    throw new Exception();
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, $"Failed to delete provider {id}");
            }
        }

    }
}
