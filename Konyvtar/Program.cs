using System.Globalization;

namespace Konyvtar
{
    internal class Program
    {
        public static void TestTagJo(Konyvtar k)
        {
            Tag t = k.Beiratkozik("Balázs", "b", "556");

            if (k.Tagja("556"))
            {
                Console.WriteLine("Sikeres tag lekérés");
            }
            else
            {
                Console.WriteLine("Sikertelen tag lekérés");
            }
        }

        public static void TestTagRossz(Konyvtar k)
        {

            if (!k.Tagja("000"))
            {
                Console.WriteLine("Sikertelen tag lekérés, mivel nincs ilyen tag");
            }
            else
            {
                Console.WriteLine("Sikeres tag lekérés, hibás Tagja metódus");
            }
        }

        public static void TestBeirJo(Konyvtar k)
        {
            Tag t = k.Beiratkozik("Egér", "e", "478");

            if (k.Tagja("478"))
            {
                Console.WriteLine("Sikeres beiratkozás");
            }
            else
            {
                Console.WriteLine("Sikertelen beiratkozás");
            }
        }

        public static void TestBeirRossz(Konyvtar k)
        {
            try
            {
                k.Beiratkozik("Herold", "h", "8910");
            }
            catch
            {

                Console.WriteLine("Már be van iratkozva");
            }
        }

        public static void TestKiirJo(Konyvtar k)
        {
            Tag t = k.Beiratkozik("Gyerek", "gy", "444");

            if (k.Tagja("444"))
            {
                Console.Write("Sikeres beiratkozás után: ");
            }
            else
            {
                Console.WriteLine("Sikertelen beiratkozás után");
            }

            k.Kiiratkozik(t);

            if (!k.Tagja("444"))
            {
                Console.WriteLine("Sikeres kiiratkozás");
            }
            else
            {
                Console.WriteLine("Sikertelen kiiratkozás");
            }
        }

        public static void TestKiirRossz(Konyvtar k)
        {
            Tag t = k.Beiratkozik("Gyerek", "gy", "444");
            k.Kiiratkozik(t);

            try
            {
                k.Kiiratkozik(t);
            }
            catch
            {

                Console.WriteLine("A személy (már) nincs beiratkozva");
            }
        }

        public static void TestMegtKolcsJo(Konyvtar k)
        {
            Konyv k1 = new Termeszettudomanyi("Békakönyv", "Előd", "piros", 123, k);

            bool megt= false;
            bool kolcs = false;

            (megt, kolcs) = k.MegtKolcs(k1);

            if(megt)
            {
                if(kolcs)
                {
                    Console.WriteLine("A könyv megtalálható és kölcsönözhető");
                }
                else
                {
                    Console.WriteLine("A könyv megtalálható, de ki van kölcsönözve az összes példány");
                }
                
            }
            else
            {
                Console.WriteLine("A könyv nem található meg");
            }
        
        }

        public static void TestMegtKolcsRossz1(Konyvtar k)
        {
            Konyv k1 = new Termeszettudomanyi("Irodalom", "Tas", "kék", 456, k);

            bool megt = false;
            bool kolcs = false;

            (megt, kolcs) = k.MegtKolcs(k1);

            if (megt)
            {
                if (kolcs)
                {
                    Console.WriteLine("A könyv megtalálható és kölcsönözhető");
                }
                else
                {
                    Console.WriteLine("A könyv megtalálható, de ki van kölcsönözve az összes példány");
                }

            }
            else
            {
                Console.WriteLine("A könyv nem található meg");
            }

        }

        public static void TestMegtKolcsRossz2(Konyvtar k)
        {
            Konyv k1 = new Termeszettudomanyi("Valami", "Nem", "ilyen", 111, k);

            bool megt = false;
            bool kolcs = false;

            (megt, kolcs) = k.MegtKolcs(k1);

            if (megt)
            {
                if (kolcs)
                {
                    Console.WriteLine("A könyv megtalálható és kölcsönözhető");
                }
                else
                {
                    Console.WriteLine("A könyv megtalálható, de ki van kölcsönözve az összes példány");
                }

            }
            else
            {
                Console.WriteLine("A könyv nem található meg");
            }
        }

        public static void TestTartozas1(Konyvtar k)
        {
            Tag t = k.Beiratkozik("Lajos", "szia", "1234");

            t.setTartozas(1000);

            if (t.getTartozas()>0)
            {
                Console.WriteLine("Működik a tartozás megadása és a tartozás lekérése");
            }
        }

        public static void TestTartozas2(Konyvtar k)
        {
            Tag t = k.Beiratkozik("Kázmér", "k", "1342");

            List<Konyv> kKonyvek = new List<Konyv>();

            kKonyvek.Add(new Termeszettudomanyi("Békakönyv", "Előd", "piros", 123, k));
            kKonyvek.Add(new Szepirodalmi("Valamimese", "Ond", "zöld", 345, k));
            kKonyvek.Add(new Szepirodalmi("Cicakönyv", "Álmos", "fehér", 234, k));

            DateTime m = DateTime.Today;

            k.Kolcsonoz(t, kKonyvek, m);

            List<Konyv> vKonyvek = new List<Konyv>();
            vKonyvek.Add(new Termeszettudomanyi("Békakönyv", "Előd", "piros", 123, k));
            vKonyvek.Add(new Szepirodalmi("Valamimese", "Ond", "zöld", 345, k));
            vKonyvek.Add(new Szepirodalmi("Cicakönyv", "Álmos", "fehér", 234, k));

            k.Visszahoz(vKonyvek, t, m.AddDays(40));

            if (t.getTartozas()>0)
            {
                Console.WriteLine("Működik a tartozás lekérése, illetve a könyvek utáni tartozás kiszámítása");
            }
            else
            {
                Console.WriteLine("Nem működik a könyvek utáni tartozás kiszámítása");
            }
        }

        public static void TestBefizet(Konyvtar k)
        {
            Tag t = k.Beiratkozik("Á", "b", "1111");

            t.setTartozas(100);

            k.Befizet(t);

            if (t.getTartozas()>0)
            {
                Console.WriteLine("nem működik a befizetés");
            }
            else
            {
                Console.WriteLine("Működik a befizetés");
            }
        
        }


        static void Main(string[] args)
        {
            Konyvtar k = new Konyvtar();

            //tagok

            TextFileReader r = new TextFileReader("tagok.txt");

            string line;

            bool st = r.ReadLine(out line);

            while (st == true)
            {
                string[] line2 = line.Split(' ');

                Tag t = k.Beiratkozik(line2[0], line2[1], line2[2]);

                st = r.ReadLine(out line);
            }

            //könyvek

            TextFileReader f = new TextFileReader("konyvek.txt");

            bool sf = f.ReadLine(out line);

            while (sf == true)
            {
                string[] line2 = line.Split(' ');

                k.Beszerez(line2[0], line2[1], line2[2], int.Parse(line2[3]), int.Parse(line2[4]), line2[5]);

                sf = f.ReadLine(out line);
            }

            //kölcsönzés

            Tag t2 = new Tag("Béla","b","234", k);

            List<Konyv> kKonyvek = new List<Konyv>();

            kKonyvek.Add(new Termeszettudomanyi("Békakönyv", "Előd", "piros", 123, k));
            kKonyvek.Add(new Szepirodalmi("Irodalom", "Tas", "kék", 456, k));
            kKonyvek.Add(new Szepirodalmi("Irodalom", "Tas", "kék", 456, k));

            DateTime m = DateTime.Today;

            k.Kolcsonoz(t2, kKonyvek, m);


            Console.WriteLine("Beiratkozás tesztjei");
            Console.WriteLine("1. eset: be tud iratkozni");
            TestBeirJo(k);
            Console.WriteLine("2.eset: nem tud beiratkozni");
            TestBeirRossz(k);

            Console.WriteLine();

            Console.WriteLine("Kiiratkozás tesztjei");
            Console.WriteLine("1. eset: be tud iratkozni és ki is tud iratkozni");
            TestKiirJo(k);
            Console.WriteLine("2. eset: nem beiratkozott személy és nem tud kiiratkozni");
            TestKiirRossz(k);

            Console.WriteLine();

            Console.WriteLine("Megtalálhatóság és kölcsönözhetőség tesztjei");
            Console.WriteLine("1. eset: megtalálható és kölcsönözhető is");
            TestMegtKolcsJo(k);
            Console.WriteLine("2. eset megtalálható, de nem kölcsönözhető, ezzel tesztelve a kölcsönzést is");
            TestMegtKolcsRossz1(k);
            Console.WriteLine("3. eset nem található meg");
            TestMegtKolcsRossz2(k);

            Console.WriteLine();

            Console.WriteLine("Tagja metódus tesztjei");
            Console.WriteLine("1. eset: beiratkozott tag, meg is található");
            TestTagJo(k);
            Console.WriteLine("2. eset: nem beiratkozott tag, nem is található meg");
            TestTagRossz(k);

            Console.WriteLine();

            Console.WriteLine("Tartozás lekérésének tesztjei");
            Console.WriteLine("1. eset: Kézzel megadott tartozás után tartozás lekérése");
            TestTartozas1(k);
            Console.WriteLine("2. eset: Tartozás könyv miatti változása után lekérés (ezzel tesztelve a visszahozást is)");
            TestTartozas2(k);

            Console.WriteLine();

            Console.WriteLine("Befizetés tesztelése");
            TestBefizet(k);






        }
    }
}
