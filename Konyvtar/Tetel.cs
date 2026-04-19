using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar
{
    public class Tetel
    {
        public Konyv konyv { get; private set;}
        public DateTime lejarat { get; private set; }
        public DateTime visszahozas;

        public Tetel(Konyv konyv,DateTime lejarat, DateTime visszahozas)
        {
            this.konyv = konyv;
            this.lejarat = lejarat;
            this.visszahozas = visszahozas;
        }
    }
}
