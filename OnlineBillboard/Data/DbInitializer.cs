using OnlineBillboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBillboard.Data
{
    public class DbInitializer
    {
        public static void Initialize(BillboardDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.bbDetails.Any()) {
                return; 
            }

            var details = new BillboardDetails[]
            {
                new BillboardDetails{ title="Christmas Promo", location="SM Downtown", events="50% sale", description="All products are 50% off", image="sample.jpg"}
            };

            foreach(BillboardDetails s in details)
            {
                context.bbDetails.Add(s);
            }
            context.SaveChanges();
        }
    }
}
