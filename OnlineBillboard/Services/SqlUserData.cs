using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBillboard.Data;
using OnlineBillboard.Models;

namespace OnlineBillboard.Services
{
    public class SqlUserData : IData
    {
        private BillboardDbContext _context;

        public SqlUserData(BillboardDbContext context)
        {            
            _context = context;
        }
  
        public IEnumerable<BillboardDetails> GetAll()
        {
            return _context.bbDetails.OrderBy(r => r.title);
        }
  
    }
}
