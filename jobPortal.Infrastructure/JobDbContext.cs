using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure
{
    public class JobDbContext :DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options)
            :base(options)
        {
            
        }
    }
}
