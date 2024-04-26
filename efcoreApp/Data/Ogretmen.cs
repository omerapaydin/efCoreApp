using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class Ogretmen
    {
         [Key]
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
         public string AdSoyad { 
            get
            {
                return this.Ad + " " + this.Soyad;
            }
            
             }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        public DateTime BaslamaTarih { get; set; }
    }
}