using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUtazas
{
    class Program
    {
        static List<UtasAdat> utas_adatok = new List<UtasAdat>();
        static void Main(string[] args)
        {
            AdatokLetarolasa();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();

            Console.ReadKey();
        }

        private static void Feladat5()
        {
            var ervenyes_utasok = utas_adatok.Where(x => x.ervenyessegi_ido.Length == 8 && (x.ervenyessegi_ev > x.felszallas_ev || x.ervenyessegi_ev >= x.felszallas_ev && x.ervenyessegi_honap > x.felszallas_honap || x.ervenyessegi_ev >= x.felszallas_ev && x.ervenyessegi_honap >= x.felszallas_honap && x.ervenyessegi_nap >= x.felszallas_nap)).ToList();
            int ingyenes_db = ervenyes_utasok.Where(x => x.jegy_tipus == "NYP" || x.jegy_tipus == "RVS" || x.jegy_tipus == "GYK").Count();
            int kedvezmenyes_db = ervenyes_utasok.Where(x => x.jegy_tipus == "TAB" || x.jegy_tipus == "NYB").Count();

            Console.WriteLine($"5. feladat" +
                $"\nIngyenesen utazók száma: {ingyenes_db} fő" +
                $"\nA kedvezményesen utazók száma: {kedvezmenyes_db} fő");
        }

        static void Feladat4()
        {
            var legtobb_felszallas = utas_adatok.GroupBy(x => x.sorszam).OrderByDescending(x => x.Count()).ThenBy(x => x.Key).FirstOrDefault();

            Console.WriteLine($"4. feladat" +
                $"\nA legtöbb utas ({legtobb_felszallas.Count()} fő) a {legtobb_felszallas.Key}. megállóban proóbált felszállni.");
        }

        static void Feladat3()
        {
            int elutasitott_utasok = utas_adatok.Where(x => x.ervenyessegi_ido == "0" || (x.ervenyessegi_ido.Length == 8 && (x.ervenyessegi_ev < x.felszallas_ev || x.ervenyessegi_ev <= x.felszallas_ev && x.ervenyessegi_honap < x.felszallas_honap || x.ervenyessegi_ev <= x.felszallas_ev && x.ervenyessegi_honap <= x.felszallas_honap && x.ervenyessegi_nap < x.felszallas_nap))).Count();

            Console.WriteLine($"3. feladat" +
                $"\nA buszra {elutasitott_utasok} utas nem szállhatott fel");
        }

        static void Feladat2()
        {
            Console.WriteLine($"2. feladat" +
                $"\nA buszra {utas_adatok.Count} utas akart felszállni.");
        }

        static void AdatokLetarolasa()
        {
            string[] f = File.ReadAllLines("utasadat.txt");

            foreach (var line in f)
            {
                utas_adatok.Add(new UtasAdat(line));
            }

            //Console.WriteLine($"{utas_adatok[0].sorszam} {utas_adatok[0].felszallas_ev}.{utas_adatok[0].felszallas_honap}.{utas_adatok[0].felszallas_nap} {utas_adatok[0].felszallas_ora}:{utas_adatok[0].felszallas_perc} {utas_adatok[0].jegy_tipus} {utas_adatok[0].ervenyessegi_ev}.{utas_adatok[0].ervenyessegi_honap}.{utas_adatok[0].ervenyessegi_nap}");
        }
    }
}
