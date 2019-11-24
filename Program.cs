using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2005oktVigenere
{
    class Program
    {
        static String nyiltSzoveg;
        static String atalakitott;
        static String kulcs;
        static String kulcsMondat;
        static String kodoltSzoveg;
        static String angolABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static void Elso()
        {
            // Nyílt szöveg bekérése
            Console.WriteLine("1. feladat");
            Console.Write("Kérek egy max 255 nyílt szöveget: ");
            nyiltSzoveg = Console.ReadLine();
        }

        static void Masodik()
        {
            Console.WriteLine("\n2. feladat");
            Console.WriteLine("Nyílt szöveg átalakítása");
            // legyen csupa nagybetű
            nyiltSzoveg = nyiltSzoveg.ToUpper();

            // magyar spec betűk átváltása
            String magyar = "ÁÉÍÓÖŐÚÜŰ";
            String angol = "AEIOOOUUU";
            String temp = "";

            for (int i = 0; i < nyiltSzoveg.Length; i++)
            {

                // ha a karakter magyar ékezetes betű
                // akkor lecseréljük a megfelelő angol betűre
                int hely = magyar.IndexOf(nyiltSzoveg[i]);
                if( hely > -1 )
                {
                    temp += angol[hely];
                }
                else
                {
                    temp += nyiltSzoveg[i];
                }
            }

            atalakitott = temp;

            // felesleges karakterek kiszűrése
            temp = "";
            for (int i = 0; i < atalakitott.Length; i++)
            {
                if (angolABC.Contains(atalakitott[i]))
                {
                    temp += atalakitott[i];
                }
            }

            atalakitott = temp;

        }

        static void Harmadik()
        {
            Console.WriteLine("\n3. feladat");
            Console.WriteLine("Átalakított nyílt szöveg:");
            Console.WriteLine(atalakitott);
        }

        static void Negyedik()
        {
            Console.WriteLine("\n4. feladat");
            Console.Write("Kérek egy rendes max 5 betűs kulcsszót: ");
            kulcs = Console.ReadLine().ToUpper();
            Console.WriteLine(kulcs);
        }

        static void Otodik()
        {
            Console.WriteLine("\n5. feladat");
            int hanyszor = atalakitott.Length / kulcs.Length + 1;
            string temp = "";
            for (int i = 0; i < hanyszor; i++)
            {
                temp += kulcs;
            }

            kulcsMondat = temp.Substring(0, atalakitott.Length);

            Console.WriteLine(atalakitott);
            Console.WriteLine(kulcsMondat);
        }


        static void Hatodik()
        {
            Console.WriteLine("\n6. feladat");
            String[] tabla = new String[26];

            StreamReader file = new StreamReader("vtabla.dat");

            for (int i = 0; i < 26; i++)
            {
                tabla[i] = file.ReadLine();
            }

            file.Close();

            String temp = "";
            for (int i = 0; i < atalakitott.Length; i++)
            {
                int sor = angolABC.IndexOf(atalakitott[i], 0);
                int oszlop = angolABC.IndexOf(kulcsMondat[i], 0);
                temp += tabla[sor].Substring(oszlop, 1);
            }

            kodoltSzoveg = temp;
            
        }

        static void Hetedik()
        {
            Console.WriteLine("\n7. feladat");
            Console.WriteLine("Kódolt szöveg:");
            Console.WriteLine(kodoltSzoveg);

            StreamWriter file = new StreamWriter("kodolt.dat");
            file.WriteLine(kodoltSzoveg);
            file.Close();
        }

        static void Main(string[] args)
        {
            Elso();
            Masodik();
            Harmadik();
            Negyedik();
            Otodik();
            Hatodik();
            Hetedik();

            Console.ReadKey();

        }
    }
}
