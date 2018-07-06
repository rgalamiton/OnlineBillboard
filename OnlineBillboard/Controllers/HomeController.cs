using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBillboard.Data;
using OnlineBillboard.Models;

namespace OnlineBillboard.Controllers
{
    public class HomeController : Controller
    {
        private BillboardDbContext _context;

        public HomeController(BillboardDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var details = await _context.bbDetails.AsNoTracking().SingleOrDefaultAsync(d => d.id == id);

            if (details == null)
            {
                return View();
            }
            return View(details);
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
