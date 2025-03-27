using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUtazas
{
    class UtasAdat
    {
        public int sorszam {  get; set; }
        public string felszallas_datum {  get; set; }
        public int felszallas_ev { get; set; }
        public int felszallas_honap { get; set; }
        public int felszallas_nap { get; set; }
        public int felszallas_ora { get; set; }
        public int felszallas_perc { get; set; }
        public int kartya_azonosito {  get; set; }
        public string jegy_tipus {  get; set; }
        public string ervenyessegi_ido {  get; set; }
        public int ervenyessegi_ev { get; set; }
        public int ervenyessegi_honap { get; set; }
        public int ervenyessegi_nap { get; set; }

        public UtasAdat(string sor)
        {
            string[] sz = sor.Split(' ');

            sorszam = int.Parse(sz[0]);

            felszallas_datum = sz[1];
            felszallas_ev = int.Parse(felszallas_datum.Substring(0, 4));
            felszallas_honap = int.Parse(felszallas_datum.Substring(4, 2));
            felszallas_nap = int.Parse(felszallas_datum.Substring(6, 2));
            felszallas_ora = int.Parse(felszallas_datum.Substring(9, 2));
            felszallas_perc = int.Parse(felszallas_datum.Substring(11, 2));

            kartya_azonosito = int.Parse(sz[2]);
            jegy_tipus = sz[3];

            ervenyessegi_ido = sz[4];
            if (ervenyessegi_ido.Length == 8)
            {
                ervenyessegi_ev = int.Parse(ervenyessegi_ido.Substring(0, 4));
                ervenyessegi_honap = int.Parse(ervenyessegi_ido.Substring(4, 2));
                ervenyessegi_nap = int.Parse(ervenyessegi_ido.Substring(6, 2));
            }
            else
            {
                ervenyessegi_ev = 0;
                ervenyessegi_honap = 0;
                ervenyessegi_nap = 0;
            }
        }
    }
}
