using ApartMgr.Data;
using ApartMgr.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.Controllers.Api
{
    [Route("api/periods")]
    public class PeriodApiController: Controller
    {
        private readonly IRepository<Period> _periodRepository;

        public PeriodApiController(IRepository<Period> periodRepository)
        {
            _periodRepository = periodRepository;
        }

        [HttpGet()]
        public IActionResult GetPeriods()
        {
            try
            {
                var periods = _periodRepository.GetAll();
                return Ok(periods);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to get periods");
            }
        }
    }
}
