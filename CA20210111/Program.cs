using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA20210111
{
    class Program
    {
        static List<Csapat> csapatok;
        static int elso = -1;
        static void Main()
        {
            F00();
            F01();
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            F08();
            Console.ReadKey(true);
        }

        private static void F08()
        {
            var sw = new StreamWriter(@"..\..\Res\legtobbszor.txt");
            csapatok.Where(cs => cs.ReszvetelSzam >= 10)
                //.Select(cs => new { cs.Orszag, cs.ElsoRszvetelOtaElteltEv, })
                .ToList().ForEach(e => sw.WriteLine($"{e.Orszag}: {e.ElsoRszvetelOtaElteltEv}"));
            sw.Close();
            Console.WriteLine("\n8. feladat: legtobbszor.txt kész!");
        }

        private static void F07()
        {
            if (elso == -1)
                throw new Exception("Ez a feladat nem megvalósítható, ha a 4. feladat még nem futott le");
            var r = csapatok.Where(cs => cs.Orszag == "Magyarország");
            Console.WriteLine($"\n7. feladat: Magyarország " +
                $"{(r.Count() == 0 || elso != r.First().ElsoReszvetel ? "nem volt ott" : "ott volt")}" +
                $" az első VB-n.");
        }
            

        private static void F06()
        {
            var r = csapatok.Where(cs => cs.Orszag == "Szlovákia");
            Console.WriteLine($"\n6. feladat: Szlovákia legjobb eredménye: " +
                $"{(r.Count() == 0 ? "nincs" : r.First().LejobbEredmeny)}");
        }

        private static void F05() =>
            Console.WriteLine($"\n5. feladat: Eddig " +
                $"{csapatok.Where(cs => cs.LejobbEredmeny.Contains("Világbajnok")).Count()}" +
                $" ország csapata volt világbajnok");


        private static void F04() =>
            Console.WriteLine($"\n4. feladat: Az első VB-t " +
                $"{elso = csapatok.Min(cs => cs.ElsoReszvetel)}" +
                $"-ban rendezték");

        private static void F03()
        {
            Console.Write("\n3. feladat: ");
            string[] benelux = { "Belgium", "Hollandia", "Luxemburg", };
            var sum = csapatok.Where(cs => benelux.Contains(cs.Orszag))
                .Sum(cs => cs.ReszvetelSzam);
            Console.WriteLine($"A BeNeLux országok összesen {sum} alkalommal vettek részt a VB-n");
        }

        private static void F02()
        {
            Console.WriteLine("\n2. feladat: 2018-as VB csapatai:");
            var legutobbi = csapatok
                .Where(cs => cs.LegutobbiReszvetel == 2018)
                .Select(cs => cs.Orszag).ToArray();
            Console.Write("\t");
            for (int i = 0; i < legutobbi.Length; i++)
            {
                Console.Write("{0, -14}", legutobbi[i]);
                if ((i + 1) % 4 == 0) Console.Write("\n\t");
            }
            Console.SetCursorPosition(0, Console.CursorTop);
        }

        private static void F01() => 
            Console.WriteLine($"\n1. feladat: csapatok száma: {csapatok.Count}");

        private static void F00()
        {
            csapatok = new List<Csapat>();
            var sr = new StreamReader(@"..\..\Res\fociVBk.csv", Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
                csapatok.Add(new Csapat(sr.ReadLine()));
        }
    }
}
