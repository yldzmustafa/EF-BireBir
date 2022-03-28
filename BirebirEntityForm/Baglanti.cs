using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BirebirEntityForm
{
    class Baglanti:DbContext
    {
        public Baglanti() : base()
        {

        }
        public DbSet<OgrenciT> ogrenciTs { get; set; }
        public DbSet<Adress> adresses { get; set; }
    }
}
