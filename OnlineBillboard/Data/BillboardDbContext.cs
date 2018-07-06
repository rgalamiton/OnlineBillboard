using Microsoft.EntityFrameworkCore;
using OnlineBillboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBillboard.Data
{

    public class BillboardDbContext: DbContext 
    {
        public BillboardDbContext(DbContextOptions<BillboardDbContext> options): base(options)
        {

        }
        public DbSet<BillboardDetails> bbDetails { get; set; }
    }
}
