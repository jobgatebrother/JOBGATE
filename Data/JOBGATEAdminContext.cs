using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JOBGATE.Models;

namespace JOBGATE.Data
{
    public class JOBGATEAdminContext : DbContext
    {
        public JOBGATEAdminContext (DbContextOptions<JOBGATEAdminContext> options)
            : base(options)
        {
        }

        public DbSet<JOBGATE.Models.IndustryCodeList> IndustryCodeList { get; set; }
    }
}
