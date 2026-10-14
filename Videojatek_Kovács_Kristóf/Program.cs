using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Videojatek_Kovács_Kristóf
{
    internal class Program
    {
        static List<Videojatek> videojatek = new List<Videojatek>();
        static void Main(string[] args)
        {
            Beolvas();
            VideojatekokKiir();

            /*Console.WriteLine($"1.feladat");
            videojatek.Where(x => x.ertekeles >= 9).ToList().ForEach(w => Console.WriteLine(w.nev));

            Console.WriteLine($"2.feladat");
            videojatek.Where(x => x.platform == "Nintendo Switch" && x.kiadas >= 2015 && x.ertekeles >= 8).ToList().ForEach(x => Console.WriteLine(x.nev));
            

            Console.WriteLine($"3.feladat");
            videojatek.OrderByDescending(x => x.kiadas).ToList().ForEach(x => Console.WriteLine(x.nev));
            

            Console.WriteLine($"4.feladat");
            videojatek.OrderByDescending(x => x.ertekeles).Take(10).ToList().ForEach(x => Console.WriteLine($"{x.nev, -25}  {x.ertekeles}"));
            


            Console.WriteLine($"5.feladat");
            videojatek.GroupBy(x => x.platform).Select(x => new
            {
                platform = x.Key,
                darab = x.Count()
            }).ToList().ForEach(x => Console.WriteLine(x));
           
            Console.WriteLine($"6.feladat");
            videojatek.GroupBy(x => x.tipus).Select(x => new
            {
                platform = x.Key,
                darab = x.Count()
            }).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine($"7.feladat");
            Console.WriteLine(videojatek.Average(x => x.ertekeles)); 
           

            Console.WriteLine($"8.feladat");
            videojatek.GroupBy(x => x.platform).Select(x => new
            {
                platform = x.Key,
                atlag = x.Average(y => y.ertekeles)
            }).OrderByDescending(x => x.atlag).Take(1).ToList().ForEach(x => Console.WriteLine(x.platform));
             

            Console.WriteLine($"9.feladat");
            Console.WriteLine($"Maximum: {videojatek.Max(x => x.ertekeles)}");
            Console.WriteLine($"Minimum: {videojatek.Min(x => x.ertekeles)}");
            
            Console.WriteLine("10.feladat");
            videojatek.Select(x => x.tipus).Distinct().ToList().ForEach(x => Console.WriteLine(x));
           
            Console.WriteLine("11.feladat");
            var lista = videojatek.Select(x => new { nev = x.nev, kiadas = x.kiadas }).ToList();
            lista.ForEach(x => Console.WriteLine($"{x.nev}, {x.kiadas}"));
            
            Console.WriteLine("12.feladat");
            videojatek.Where(x => x.tipus == "Action").Select(x => new
            {
                tipus = x.tipus,
                nev = x.nev,
                kiadas = x.kiadas,
                ertekeles = x.ertekeles

            }).OrderByDescending(x => x.ertekeles).ToList().ForEach(x => Console.WriteLine($"Action játékok: {x.nev} {x.kiadas} {x.ertekeles} {x.tipus}"));
             
            Console.WriteLine("13.feladat");
            videojatek.GroupBy(x => x.tipus).Select(x => new
            {
                tipus = x.Key,
                atlag = x.Average(y => y.ertekeles)
            }).ToList().ForEach(x => Console.WriteLine(x));
            

            Console.WriteLine("14.feladat");
            videojatek.Where(x => x.kiadas >= 2005).ToList().ForEach(x => Console.WriteLine($"{x.nev} {x.platform}"));
            */

            Console.WriteLine("15.feladat");
            videojatek.GroupBy(x => x.platform).Select(x => new
            {
                platform = x.Key,
                ertekeles = x.OrderByDescending(y => y.ertekeles).Take(1),
                nev = x.Select(z => z.nev)

            }).ToList().ForEach(x => Console.WriteLine($"{x.nev} {x.platform} {x.ertekeles} "));


            Console.ReadKey();
        }
        private static void VideojatekokKiir()
        {
            foreach (var item in videojatek)
            {
                Console.WriteLine(item.nev);
            }
        }
        private static void Beolvas()
        {
            try
            {
                videojatek = File.ReadAllLines("games_dataset.csv")
                    .Skip(1)
                    .Select(sor => sor.Split(';'))
                    .Select(adat => new Videojatek(
                        adat[0],
                        adat[1],
                        adat[2],
                        int.Parse(adat[3]),
                        double.Parse(adat[4])
                        )).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hiba! {e.Message}");
            }
        }
    }
}
