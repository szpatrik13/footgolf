using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace footgolf
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public string Kategoria { get; set; }
        public string Egyesulet { get; set; }
        public int[] Pontok { get; set; }

        public int OsszPont => PontSzamitas(Pontok);

        public Versenyzo(string nev, string kat, string egy, int[] pontok)
        {
            Nev = nev;
            Kategoria = kat;
            Egyesulet = egy;
            Pontok = pontok;
        }
        public int PontSzamitas(int[] pontok)
        {
            Array.Sort(pontok);
            int ossz = 0;
            for (int i = 0; i < pontok.Length; i++)
            {
                if (pontok[i] != 0 && i < 2) pontok[i] = 10;
                ossz += pontok[i];
            }
            return ossz;
        }
    }
    class Program
    {
        static List<Versenyzo> versenyzok;
        static void Main(string[] args)
        {
            Feladat02();
            Feladat03();
            Feladat04();
            Console.ReadKey();
        }
        private static void Feladat04()
        {
            double nok = versenyzok.Count(a => a.Kategoria.ToLower().Contains("noi"));
            double arany = (nok *100)/versenyzok.Count();
            Console.WriteLine("4. feladat: A női versenyzők aránya: {0:0.00}%",arany);
            
        }
        private static void Feladat03()
        {
            Console.WriteLine("3. feladat: Versenyzők száma: "+versenyzok.Count());
        }
        private static void Feladat02()
        {
            versenyzok = new List<Versenyzo>();

            var sr = new StreamReader(@"..\..\Res\fob2016.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                var tomb = sr.ReadLine().Split(';');

                versenyzok.Add(new Versenyzo(tomb[0],tomb[1],tomb[2],
                    new int[] {int.Parse(tomb[3]), int.Parse(tomb[4]), int.Parse(tomb[5]), int.Parse(tomb[6]), int.Parse(tomb[7]), int.Parse(tomb[8]), int.Parse(tomb[9]), int.Parse(tomb[10]) }));
            }
            sr.Close();
        }
    }
}
