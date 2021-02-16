using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jakab_acs_eszter_tesztverseny_2021._01._26
{
    class Program
    {
        struct Adat 
        {
            public string kod;
            public string valaszok;
        }
        static void Main(string[] args)
        {
            //1.feladat
            Adat[] adatok = new Adat[500];
            StreamReader beolvas = new StreamReader(@"E:\OneDrive - Kisvárdai SZC Móricz Zsigmond Szakgimnáziuma és Szakközépiskolája\Oktatas\Programozas\Jakab_Acs_Eszter\Erettsegi_feladatok\2017-majus_tesztverseny\valaszok.txt");
            string helyes_valaszok = beolvas.ReadLine();
            int n = 0;
            while (!beolvas.EndOfStream) 
            {
                string sor = beolvas.ReadLine();
                string[] db = sor.Split();
                adatok[n].kod = db[0];
                adatok[n].valaszok = db[1];
                n++;
            }
            beolvas.Close();
            Console.WriteLine("1. feladat: Az adatok beolvasása");

            //2.feladat
            Console.WriteLine($"2. feladat: A vetélkedőn {n} versenyző indult.");

            //3.feladat
            Console.Write("3. feladat: A versenyző azonosítója = ");
            string kod = Console.ReadLine();
            string v_valasza = null;
            for (int i=0; i<n; i++) 
            {
                if (kod == adatok[i].kod) 
                {
                    Console.WriteLine($"{adatok[i].valaszok}\t(a versenyző válasza)");
                    v_valasza = adatok[i].valaszok;
                    break;
                }
            }

            //4.feladat
            char[] kar_v_valasza = v_valasza.ToCharArray();
            char[] helyes_tomb = helyes_valaszok.ToCharArray();
            Console.WriteLine($"4.feladat:\n{helyes_valaszok}\t(a helyes megoldás)");
            string talalatok = null;
            for (int i=0; i<kar_v_valasza.Length; i++)
            {
                if (kar_v_valasza[i] == helyes_tomb[i])
                {
                    talalatok += "+";
                }
                else
                {
                    talalatok += " ";
                }
            }
            Console.WriteLine($"{talalatok}\t(a versenyző helyes válaszai)");

            //5.feladat
            Console.Write("5. feladat: A feladat sorszáma= ");
            int sorszam = int.Parse(Console.ReadLine());
            int szamlalo = 0;
            for (int i=0;i<n;i++)
            {
                if (helyes_valaszok[sorszam-1] == adatok[i].valaszok[sorszam-1])
                {
                    szamlalo++;
                }
            }
            double szazalek =  (double)szamlalo  /  n  *  100;
            Console.WriteLine($"A feladatra {szamlalo} fő, a versenyzők {Math.Round(szazalek,2)}%-a adott helyes választ.");

            //6.feladat
            //Console.WriteLine(pontok(helyes_valaszok, adatok[0].valaszok));
            //Fájba írás
            StreamWriter ir = new StreamWriter(@"E:\OneDrive - Kisvárdai SZC Móricz Zsigmond Szakgimnáziuma és Szakközépiskolája\Oktatas\Programozas\Jakab_Acs_Eszter\Erettsegi_feladatok\2017-majus_tesztverseny\pontok.txt");
            int max = pontok(adatok[0].valaszok, helyes_valaszok);
            for (int i=0;i<n;i++)
            {
                ir.WriteLine(adatok[i].kod + " " + pontok(helyes_valaszok, adatok[i].valaszok));
                if (max < pontok(adatok[i].valaszok, helyes_valaszok))
                {
                    max = pontok(adatok[i].valaszok, helyes_valaszok);
                }
            }
            ir.Close();

            //7.feladat
            for (int j = 1;j<4;j++)
            {
                bool volt = false;
                for (int i = 0; i < n; i++)
                {

                    if (max == pontok(adatok[i].valaszok, helyes_valaszok))
                    {
                        Console.WriteLine($"{j}. díj ({max} pont): {adatok[i].kod}");
                        volt = true;
                    }
                }
                max--;
                if (!volt)
                {
                    j--;
                }
            }
            
            Console.ReadKey();
        }

        //6.feladat: függvény készítése
        static int pontok(string helyes_valasz, string versenyzo_valasz)
        {
            int pont = 0;
            for (int i = 0;i<5;i++)
            {
                if (helyes_valasz[i] == versenyzo_valasz[i])
                {
                    pont += 3;
                }
            }

            for (int i = 5; i < 10; i++)
            {
                if (helyes_valasz[i] == versenyzo_valasz[i])
                {
                    pont += 4;
                }
            }

            for (int i = 10; i < 13; i++)
            {
                if (helyes_valasz[i] == versenyzo_valasz[i])
                {
                    pont += 5;
                }
            }

            if (helyes_valasz[13] == versenyzo_valasz[13])
            {
                pont += 6;
            }
            return pont;
        }
    }
}
