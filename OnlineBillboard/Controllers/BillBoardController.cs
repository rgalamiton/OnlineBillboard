using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngularSpa.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBillboard.Data;
using OnlineBillboard.Models;
using OnlineBillboard.Services;

namespace OnlineBillboard.Controllers
{
    public class BillBoardController : Controller
    {
        private BillboardDbContext _context;
        private readonly IHostingEnvironment _environment;
        private readonly IData dataDetails;

        public BillBoardController(BillboardDbContext context, IHostingEnvironment env, IData idata)
        {
            _context = context;
            _environment = env;
            dataDetails = idata;
        }

        public IActionResult Index()
        {
            var str = _context.bbDetails.OrderBy(r => r.id);
            return View(str);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var details = _context.bbDetails.FirstOrDefault(r => r.id == id);

            if (details == null)
            {
                return NotFound();
            }
            return View(details);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("title,location,events,description")] BillboardDetails details, IFormFile image)
        {
            if (ModelState.IsValid)
            {             
                var filePath = Path.Combine(_environment.WebRootPath, "UploadedImages", Path.GetFileName(image.FileName));
                var fileName = Path.GetFileName(image.FileName);
                ViewBag.Files = Path.Combine(_environment.WebRootPath, "UploadedImages");
                await image.CopyToAsync(new FileStream(filePath, FileMode.Create));

                details.image = fileName; 
                _context.Add(details);              
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(details);
        }

        
        
    }
}
