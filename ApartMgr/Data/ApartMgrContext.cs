using ApartMgr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.Data
{
    public class ApartMgrContext: DbContext
    {
        public ApartMgrContext(DbContextOptions<ApartMgrContext> options): base(options)
        {  }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

    }
}
