using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar
{
    public abstract class Konyv
    {
        protected string cim;
        protected string szerzo;
        protected string kiado;
        protected int ISBN;
        protected Konyvtar kKonyvtar;

        public Konyv(string cim, string szerzo, string kiado, int ISBN, Konyvtar kKonyvtar)
        {
            this.cim = cim;
            this.szerzo = szerzo;
            this.kiado = kiado;
            this.ISBN = ISBN;
            this.kKonyvtar = kKonyvtar;
        }

        public virtual int Ertek() { return 0; }

        public void Leselejtez()
        {
            kKonyvtar = null;
        }

        public int getISBN()
        {
            return ISBN;
        }
    }

    public class Termeszettudomanyi : Konyv
    {
        public Termeszettudomanyi(string cim, string szerzo, string kiado, int ISBN, Konyvtar k) : base(cim, szerzo, kiado, ISBN, k)
        {

        }

        public override int Ertek()
        {
            if (kKonyvtar.KonyvDb(this) <=5)
            {
                return 100;
            }
            else if (kKonyvtar.KonyvDb(this) <= 10)
            {
                return 60;
            }
            else
            {
                return 100;
            }
        }
    }

    public class Szepirodalmi : Konyv
    {
        public Szepirodalmi(string cim, string szerzo, string kiado, int ISBN, Konyvtar k) : base(cim, szerzo, kiado, ISBN, k)
        {

        }

        public override int Ertek()
        {
            if (kKonyvtar.KonyvDb(this) <= 5)
            {
                return 50;
            }
            else if (kKonyvtar.KonyvDb(this) <= 10)
            {
                return 30;
            }
            else
            {
                return 10;
            }
        }
    }

    public class Ifjusagi : Konyv
    {
        public Ifjusagi(string cim, string szerzo, string kiado, int ISBN, Konyvtar k) : base(cim, szerzo, kiado, ISBN, k)
        {

        }

        public override int Ertek()
        {
            if (kKonyvtar.KonyvDb(this) <= 5)
            {
                return 30;
            }
            else if (kKonyvtar.KonyvDb(this) <= 10)
            {
                return 10;
            }
            else
            {
                return 5;
            }
        }
    }
}
