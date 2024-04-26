using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class OgrenciController:Controller
    {

        private readonly DataContext _context;
        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Ogrenciler.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
             return RedirectToAction("Index");
        }
         public async Task<IActionResult> Edit(int? id)
        {
               if(id==null)
            {
                return NotFound();
            }
            var  ogr = await _context.Ogrenciler.Include(o=>o.KursKayitlari).ThenInclude(o=>o.Kurs).FirstOrDefaultAsync(p=>p.OgrenciId==id);

            return View(ogr);
        }
        [HttpPost]
         public async Task<IActionResult> Edit(int? id , Ogrenci model)
        {
             if(id != model.OgrenciId)
             {
                return NotFound();
             }else
             {
                 _context.Ogrenciler.Update(model);
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
            var  ogr = await _context.Ogrenciler.FindAsync(id);

            return View(ogr);
        }
        [HttpPost]
         public async Task<IActionResult> Delete([FromForm]int id)
        {
            var ogrenc = await _context.Ogrenciler.FindAsync(id);
            _context.Ogrenciler.Remove(ogrenc);
            await _context.SaveChangesAsync();
             return RedirectToAction("Index");
        }
    }
}