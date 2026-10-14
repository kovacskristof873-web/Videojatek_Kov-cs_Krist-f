using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videojatek_Kovács_Kristóf
{
    //Játék neve;Típus;Platform;Kiadás éve;Felhasználói értékelés
    public class Videojatek
    {
       

        public Videojatek(string nev, string tipus, string platform, int kiadas, double ertekeles)
        {
            this.nev = nev;
            this.tipus = tipus;
            this.kiadas = kiadas;
            this.platform = platform;
            this.ertekeles = ertekeles;
        }

        public string nev { get; set; }
        public string tipus { get; set; }
        public string platform { get; set; }
        public int kiadas { get; set; }
        public double ertekeles { get; set; }
        
    }
}
