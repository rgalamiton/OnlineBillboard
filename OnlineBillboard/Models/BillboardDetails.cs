using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBillboard.Models
{
    public class BillboardDetails
    {
        public int id { get; set; }
        public string title { get; set; }
        public string location { get; set; } 
        public string description { get; set; }
        public string image { get; set; }

        public string events { get; set; }
    }
}
