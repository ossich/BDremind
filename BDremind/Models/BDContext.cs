using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BDremind.Models
{
    public class BDContext: DbContext
    {
     public BDContext(DbContextOptions<BDContext> options)
     : base(options)
        {
        }

        public DbSet<BDItem> BDItems { get; set; }

    }
}