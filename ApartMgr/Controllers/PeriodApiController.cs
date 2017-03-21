using ApartMgr.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.Controllers
{
    [Route("api/periods")]
    public class PeriodApiController: Controller
    {
        private readonly IPeriodRepository _periodRepository;

        public PeriodApiController(IPeriodRepository periodRepository)
        {
            _periodRepository = periodRepository;
        }

        [HttpGet()]
        public IActionResult GetPeriods()
        {
            var periods = _periodRepository.GetPeriods();
            return new JsonResult(periods);

        }
    }
}
