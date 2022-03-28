using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirebirEntityForm
{
    class OgrenciT
    {
        public int Id { get; set; }
        public string ad { get; set; }
        public string Soyad { get; set; }
        public virtual Adress Address { get; set; }
    }
}
