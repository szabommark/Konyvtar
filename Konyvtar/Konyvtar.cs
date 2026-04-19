using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar
{
    public class Konyvtar
    {
        private List<Konyv> konyvek;
        private List<Tag> tagok;
        private List<Kolcsonzes> kolcsonzesek;

        public Konyvtar()
        {
            konyvek = new List<Konyv>();
            tagok = new List<Tag>();
            kolcsonzesek = new List<Kolcsonzes>();
        }

        public int KonyvDb(Konyv k)
        {
            int counter = 0;
            for (int i = 0; i < konyvek.Count; i++)
            {
                if (konyvek[i] == k)
                {
                    counter++;
                }
            }
            return counter;
        }

        public void Beszerez(string c, string sz, string k, int i, int db, string mufaj)
        {
            Konyv k1;

            if (mufaj == "t")
            {
                k1 = new Termeszettudomanyi(c, sz, k, i, this);
            }
            else if (mufaj == "sz")
            {
                k1 = new Szepirodalmi(c, sz, k, i, this);
            }
            else if (mufaj == "i")
            {
                k1 = new Ifjusagi(c, sz, k, i, this);
            }
            else
            {
                throw new Exception("book type not found");
            }

            for (int j = 0; j < db; j++)
            {
                konyvek.Add(k1);
            }
        }

        public void Leselejtez(Konyv k)
        {
            if (!konyvek.Contains(k))
            {
                throw new Exception("this book does not exist in the library");
            }
            else
            {
                k.Leselejtez();
                konyvek.Remove(k);
            }
        }

        public Tag Beiratkozik(string n, string c, string i)
        {
            Tag t = new Tag(n, c, i, this);

            if (!Tagja(i))
            {
                tagok.Add(t);
            }
            else
            {
                throw new Exception("this member already exists");
            }

            return t;
        }

        public void Kiiratkozik(Tag t)
        {

            if (!Tagja(t.igSzam))
            {
                throw new Exception("not a member of the library");
            }
            else
            {
                t.Kiiratkozik();
                for (int i = 0; i < tagok.Count; i++)
                {
                    if (t.Megegyezik(tagok[i]))
                    {
                        tagok.Remove(tagok[i]);
                    }
                }
            }
        }

        public void Befizet(Tag t)
        {
            t.Befizet();
        }

        public bool Tagja(string igSzam)
        {
            for (int i = 0; i < tagok.Count; i++)
            {
                if (tagok[i].igSzam == igSzam)
                {
                    return true;
                }
            }
            return false;
        }



        public (bool, bool) MegtKolcs(Konyv k)
        {
            bool m = false;
            bool ko = false;

            for (int i = 0; i < konyvek.Count; i++)
            {
                if (konyvek[i].getISBN() == k.getISBN())
                {
                    m = true;
                    ko = true;
                }
            }

            for (int i = 0; i < kolcsonzesek.Count; i++)
            {
                for (int j = 0; j < kolcsonzesek[i].tetelek.Count; j++)
                {
                    if (kolcsonzesek[i].tetelek[j].konyv.getISBN() == k.getISBN())
                    {
                        m = true;
                    }
                }
            }

            return (m, ko);
        }

        public void Kolcsonoz(Tag t, List<Konyv> kKonyvek, DateTime kMikortol)
        {
            Tag t1 = null;

            for (int i = 0; i < tagok.Count; i++)
            {
                if (tagok[i].Megegyezik(t))
                {
                    t1 = tagok[i];
                }
            }

            if (t1.getTartozas() == 0)
            {
                List<Tetel> kTetelek = new List<Tetel>();

                for (int i = 0; i < kKonyvek.Count; i++)
                {
                    Tetel kT = new Tetel(kKonyvek[i], kMikortol.AddDays(30), DateTime.MinValue);
                    kTetelek.Add(kT);
                }

                Kolcsonzes kCs = new Kolcsonzes(t, kMikortol, kTetelek);

                kolcsonzesek.Add(kCs);


                for (int j = 0; j < kKonyvek.Count; j++)
                {
                    t1.konyvek.Add(kKonyvek[j]);

                    for (int r = 0; r < konyvek.Count; r++)
                    {
                        if (konyvek[r].getISBN() == kKonyvek[j].getISBN())
                        {
                            konyvek.RemoveAt(r);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("member has to pay");
            }
        }

        public void Visszahoz(List<Konyv> vKonyvek, Tag t, DateTime vDatum)
        {
            int tartozas = 0;

            foreach (Konyv k in vKonyvek)
            {
                for (int i = 0; i < kolcsonzesek.Count(); i++)
                {
                    if (kolcsonzesek[i].tag.Megegyezik(t))
                    {
                        for (int j = 0; j < kolcsonzesek[i].tetelek.Count; j++)
                        {
                            if (kolcsonzesek[i].tetelek[j].konyv.getISBN() == k.getISBN())
                            {
                                kolcsonzesek[i].tetelek[j].visszahozas = vDatum;

                                if (kolcsonzesek[i].tetelek[j].lejarat < vDatum)
                                {
                                    tartozas += (int)(vDatum - kolcsonzesek[i].tetelek[j].lejarat).TotalDays * k.Ertek();
                                }
                            }
                        }
                    }
                }
            }

            foreach (Konyv k1 in vKonyvek)
            {
                foreach (Tag t1 in tagok)
                {
                    if (t1.Megegyezik(t))
                    {
                        for (int i = 0; i < t1.konyvek.Count; i++)
                        {
                            if (t1.konyvek[i].getISBN() == k1.getISBN())
                            {
                                t1.konyvek.RemoveAt(i);
                            }
                        }
                        konyvek.Add(k1);
                        t1.setTartozas(tartozas);
                    }
                }
            }
        
        }






    }
}
