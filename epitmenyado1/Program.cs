using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.SqlServer.Server;

namespace epitmenyado1
{
    internal class Program
    {
        struct Adat
        {
            public int adoszam, negyzetm;
            public string utcanev, hazszam, adosav;
            public Adat(string sor)
            {
                string[] db = sor.Split();
                adoszam = int.Parse(db[0]);
                utcanev = db[1];
                hazszam = db[2];
                adosav = db[3];
                negyzetm = int.Parse(db[4]);
            }

        }

        //függvény
        static int ado(string adosav,int negyzetm)
        {

        }
        static void Main(string[] args)
        {
            List<Adat> lista = new List<Adat>();
            foreach (var i in File.ReadAllLines("utca.txt").Skip(1))
            {
                lista.Add(new Adat(i));
            }

            //2. feladat. A mintában 543 telek szerepel.
            Console.WriteLine($"A mintában {lista.Count} telek szerepel.");

            //3.feladat
            //3. feladat. Egy tulajdonos adószáma: 68396
            //Harmat utca 22
            //Szepesi utca 17
            Console.Write("Kérem adjon meg egy adószámot: ");
            int adoszam = int.Parse(Console.ReadLine());
            bool volt_e = true;
            foreach(var i in lista)
            {
                if (i.adoszam == adoszam)
                {
                    Console.Write($"{i.utcanev} utca {i.hazszam}");
                    volt_e = false;
                }
            }
            if (volt_e==true)
            {
                Console.Write("Nem létezik ez az adószám.");
            }

            Console.ReadKey();
        }
    }
}
