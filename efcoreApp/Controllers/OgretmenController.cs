using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class OgretmenController:Controller
    {
         private readonly DataContext _context;
        public OgretmenController(DataContext context)
        {
            _context = context;
        }

         public async Task<IActionResult> Index()
        {
            
            return View(await _context.Ogretmenler.ToListAsync());
        }

         public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model)
        {
            _context.Ogretmenler.Add(model);
            await _context.SaveChangesAsync();
             return RedirectToAction("Index");
        }

            public async Task<IActionResult> Edit(int? id)
        {
               if(id==null)
            {
                return NotFound();
            }
            var  ogr = await _context.Ogretmenler.FindAsync(id);

            return View(ogr);
        }
        [HttpPost]
         public async Task<IActionResult> Edit(int? id , Ogretmen model)
        {
             if(id != model.OgretmenId)
             {
                return NotFound();
             }else
             {
                 _context.Ogretmenler.Update(model);
                 await _context.SaveChangesAsync();
             }
            

            return View(model);
        }
    }
}