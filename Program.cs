using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace HegyekMo
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] sorok = File.ReadAllLines(@"hegyekMo.txt").Skip(1).ToArray();
            Console.WriteLine($"3. feladat: Hegycsúcsok száma: {sorok.Length} db");
            // Összegzés
            int osszesMagassag = 0;
            for (int i = 0; i < sorok.Length; i++)
            {
                osszesMagassag += int.Parse(sorok[i].Split(';')[2]);
                // osszesMagassag = osszesMagassag + int.Parse(sorok[i].Split(';')[2]);
            }
            double atlagMagassag = (double)osszesMagassag / sorok.Length;
            Console.WriteLine($"4. feladat: Hegycsúcsok átlagos magassága: {atlagMagassag} m");
            #region 4+ feladat Írassa ki a Börzsöny hegység hegycsúcsainak az az átlagos magasságát az előző feladat alapján
            int osszesMagassagB = 0;
            int hegycsB = 0;
            for (int i = 0; i < sorok.Length; i++)
            {
                if (sorok[i].Split(';')[1].Contains("Börzsöny"))
                {
                    osszesMagassagB += int.Parse(sorok[i].Split(';')[2]);
                    hegycsB++;
                }
                // osszesMagassag = osszesMagassag + int.Parse(sorok[i].Split(';')[2]);
            }
            double atlagMagassagB = (double)osszesMagassagB / hegycsB++;
            Console.WriteLine($"4+. feladat: Hegycsúcsok átlagos magassága a Börzsönyben: {atlagMagassagB} m");
            #endregion
            #region 5.feladat
            // maximum kiválasztás
            int index = 0;
            int max = int.Parse(sorok[index].Split(';')[2]);

            for (int i = 0; i < sorok.Length; i++)
            {
                if (int.Parse(sorok[i].Split(';')[2]) > max)
                {
                    max = int.Parse(sorok[i].Split(';')[2]);
                    index = i;
                }
            }
            Console.WriteLine("5. feladat: A legmagasabb hegycsúcs adatai:");
            string[] legmagasabb = sorok[index].Split(';');
            Console.WriteLine($"\tNév: {legmagasabb[0]}");
            Console.WriteLine($"\tHegység: {legmagasabb[1]}");
            Console.WriteLine($"\tMagasság: {legmagasabb[2]} m");
            #endregion
            #region 5+ feladat Írassa ki a Börzsöny hegység legmagasabb hegycsúcsának az adatait az előző feladat alapján

            int indexB = -1;
            int maxB = int.MinValue;

            for (int i = 0; i < sorok.Length; i++)
            {
                if ((int.Parse(sorok[i].Split(';')[2]) > maxB) && sorok[i].Split(';')[1].Contains("Börzsöny"))
                {
                    maxB = int.Parse(sorok[i].Split(';')[2]);
                    indexB = i;
                }
            }
            Console.WriteLine("5+. feladat: A Börzsöny legmagasabb hegycsúcsának adatai:");

            string[] legmagasabbB = sorok[indexB].Split(';');
            Console.WriteLine($"\tNév: {legmagasabbB[0]}");
            Console.WriteLine($"\tHegység: {legmagasabbB[1]}");
            Console.WriteLine($"\tMagasság: {legmagasabbB[2]} m");
            #endregion
            #region 6. feladat
            Console.Write("6. feladat: Kérek egy magasságot: ");
            int magassag = int.Parse(Console.ReadLine());
            int indexK = -1;
            bool vanE = false;
            for (int i = 0; i < sorok.Length; i++)
            {
                if (sorok[i].Split(';')[1].Contains("Börzsöny"))
                {
                    if (int.Parse(sorok[i].Split(';')[2]) > magassag)
                    {
                        indexK = i;
                        vanE = true;
                        break;
                    }
                }
            }
            #endregion
            if (indexK > -1)
            {
                Console.WriteLine($"Van {magassag}m-nél magasabb hegycsúcs a Börzönyben!");
            }
            else
            {
                Console.WriteLine($"Nincs {magassag}m-nél magasabb hegycsúcs a Börzönyben!");
            }
            int darabSzam = 0;
            foreach (var sor in sorok)
            {
                if (int.Parse(sor.Split(';')[2]) * 3.280839895 > 3000)
                {
                    darabSzam++;
                }
            }
            Console.WriteLine($"7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {darabSzam}");
            Console.WriteLine("8. feladat: Hegység statisztika");
            Dictionary<string, int> hegycsucsok = new Dictionary<string, int>();
            foreach (var sor in sorok)
            {
                if (hegycsucsok.ContainsKey(sor.Split(';')[1]))
                {
                    hegycsucsok[sor.Split(';')[1]]++;
                }
                else
                {
                    hegycsucsok[sor.Split(';')[1]] = 1;
                }
            }
            foreach (var item in hegycsucsok)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value} db");
            }
            List<string> adatok = new List<string>();
            adatok.Add("Hegycsúcs neve;Magasság láb");
            for (int i = 0; i < sorok.Length; i++)
            {
                if (sorok[i].Split(';')[1].Contains("Bükk-vidék"))
                {
                    adatok.Add(sorok[i].Split(';')[0] + ";" + Math.Round(int.Parse(sorok[i].Split(';')[2]) * 3.280839895, 1));
                }
            }
            Console.WriteLine("9. feladat: bukk-videk.txt");
            File.WriteAllLines("bukk-videk.txt", adatok);
            Console.ReadKey();
        }
    }
}