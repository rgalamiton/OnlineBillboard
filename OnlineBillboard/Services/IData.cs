using OnlineBillboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBillboard.Services
{
    public interface IData
    {
       IEnumerable<BillboardDetails> GetAll();
       
    }
}
