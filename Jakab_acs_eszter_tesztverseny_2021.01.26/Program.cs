﻿using System;
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
                if (helyes_valaszok[sorszam] == adatok[i].valaszok[sorszam])
                {
                    szamlalo++;
                }
            }
            double szazalek =  (double)szamlalo  /  n  *  100;
            Console.WriteLine($"A feladatra {szamlalo} fő, a versenyzők {szazalek.ToString("0.00")}%-a adott helyes választ.");
            Console.ReadKey();
        }
    }
}
