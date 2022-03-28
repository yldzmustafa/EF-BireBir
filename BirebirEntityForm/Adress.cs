using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirebirEntityForm
{
    class Adress
    {
        [ForeignKey("ogrencitables")]
        public int ID { get; set; }
        public string Adres { get; set; }

        public virtual OgrenciT ogrencitables { get; set; }
    }
}
