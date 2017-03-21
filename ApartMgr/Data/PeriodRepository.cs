using ApartMgr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.Data
{
    public interface IPeriodRepository
    {
        IEnumerable<Period> GetPeriods();
    }

    public class PeriodRepository : IPeriodRepository
    {
        private readonly ApartMgrContext _ctx;
        public PeriodRepository(ApartMgrContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Period> GetPeriods()
        {
            return _ctx.Periods.ToList();
        }
    }
}
