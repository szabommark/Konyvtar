using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar
{
    public class Tag
    {
        private string nev;
        private string cim;
        public string igSzam { get; private set; }
        public List<Konyv> konyvek;
        private int tartozas;
        private Konyvtar konyvtar;

        public Tag(string nev, string cim, string igSzam, Konyvtar konyvtar)
        {
            this.nev = nev;
            this.cim = cim;
            this.igSzam = igSzam;
            konyvek = new List<Konyv>();
            tartozas = 0;
            this.konyvtar = konyvtar;
        }

        public int getTartozas()
        {
            return tartozas;
        }

        public void setTartozas(int t)
        {
            this.tartozas += t;
        }

        public bool Megegyezik(Tag t)
        {
            return t.igSzam == this.igSzam;
        }

        public void Befizet()
        {
            this.tartozas = 0;
        }

        public void Kiiratkozik()
        {
            if (this.tartozas != 0)
            {
                throw new Exception("member needs to pay");
            }
            else
            {
                konyvtar = null;
            }
        }
    }
}
