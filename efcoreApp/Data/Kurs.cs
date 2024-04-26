using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class Kurs
    {
        public int KursId { get; set; }
        public string? Baslik { get; set; }
        public int OgretmenId { get; set; }
        public Ogretmen Ogretmen { get; set; } = null!;
    }
}