using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class KursController:Controller
    {
        private readonly DataContext _context;
        public KursController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Kurslar.ToListAsync());
        }

         public async Task<IActionResult> Create()
        {
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(),"OgretmenId","Ad");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Kurs model)
        {
            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
             return RedirectToAction("Index");
        }

           public async Task<IActionResult> Edit(int? id)
        {
               if(id==null)
            {
                return NotFound();
            }
            var  ogr = await _context.Kurslar.FindAsync(id);

            return View(ogr);
        }
        [HttpPost]
         public async Task<IActionResult> Edit(int? id , Kurs model)
        {
             if(id != model.KursId)
             {
                return NotFound();
             }else
             {
                 _context.Kurslar.Update(model);
                 await _context.SaveChangesAsync();
             }
            

            return View(model);
        }

         public async Task<IActionResult> Delete(int? id)
        {
               if(id==null)
            {
                return NotFound();
            }
            var  ogr = await _context.Kurslar.FindAsync(id);

            return View(ogr);
        }
        [HttpPost]
         public async Task<IActionResult> Delete([FromForm]int id)
        {
            var kurs = await _context.Kurslar.FindAsync(id);
            _context.Kurslar.Remove(kurs);
            await _context.SaveChangesAsync();
             return RedirectToAction("Index");
        }

    }
}