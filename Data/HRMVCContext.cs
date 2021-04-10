using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRMVC.Models;

namespace HRMVC.Data
{
    public class HRMVCContext : DbContext
    {
        public HRMVCContext (DbContextOptions<HRMVCContext> options)
            : base(options)
        {
        }

        public DbSet<HRMVC.Models.Customer> Customer { get; set; }

        public DbSet<HRMVC.Models.query> query { get; set; }

        public DbSet<HRMVC.Models.Employeer> Employeer { get; set; }
    }
}
