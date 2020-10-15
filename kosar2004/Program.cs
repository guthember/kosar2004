using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosar2004
{
  class Program
  {
    static List<Meccs> meccsek = new List<Meccs>();

    static void MasodikFeladat()
    {
      StreamReader file = new StreamReader("eredmenyek.csv");

      file.ReadLine();

      while (!file.EndOfStream)
      {
        string[] adat = file.ReadLine().Split(';');

        meccsek.Add(
                    new Meccs(adat[0], adat[1], Convert.ToInt32(adat[2]), Convert.ToInt32(adat[3]),
                              adat[4], adat[5])
                    );
      }

      file.Close();
    }

    static void HarmadikFeladat()
    {
      Console.Write("3. feladat: Real Madrid: Hazai: ");

      int megszamol = 0;

      foreach (var m in meccsek)
      {
        if (m.Hazai == "Real Madrid")
        {
          megszamol++;
        }
      }

      var hazai = from m in meccsek
                  where m.Hazai == "Real Madrid"
                  select new { Hazai = m.Hazai };

      int hazaiDb = hazai.ToList().Count;

      var idegen = from m in meccsek
                   where m.Idegen == "Real Madrid"
                   select new { Idegen = m.Idegen };

      int idegenDb = idegen.ToList().Count;

      Console.WriteLine($"{hazaiDb}, Idegen: {idegenDb}");

    }

    static void NegyedikFeladat()
    {
      Console.Write("4. feladat: Volt döntetlen? ");

      var dontetlen = from m in meccsek
                      where m.HPont == m.IPont
                      select m;

      int db = dontetlen.ToList().Count;

      if (db == 0)
      {
        Console.WriteLine("nem");
      }
      else
      {
        Console.WriteLine("igen");
      }
    }

    static void OtodikFeladat()
    {
      Console.Write("5. feladat: barcelonai csapat neve: ");

      var barca = from m in meccsek
                  where m.Hazai.Contains("Barcelona")
                  select new { Hazai = m.Hazai };

      var barcaNev = barca.ToArray()[0].Hazai;

      Console.WriteLine(barcaNev);

      // vagy

      int i = 0;

      while (!meccsek[i].Hazai.Contains("Barcelona"))
      {
        i++;
      }

    }

    static void HatodikFeladat()
    {
      Console.WriteLine("6. feladat:");

      var november = from m in meccsek
                     where m.Ido == "2004-11-21"
                     select new { Hazai = m.Hazai, Idegen = m.Idegen, HP = m.HPont, IP = m.IPont };

      foreach (var n in november)
      {
        Console.WriteLine($"\t{n.Hazai} - {n.Idegen} ({n.HP}:{n.IP})");
      }
    }

    static void Main(string[] args)
    {
      MasodikFeladat();
      HarmadikFeladat();
      NegyedikFeladat();
      OtodikFeladat();
      HatodikFeladat();

      Console.ReadLine();
    }
  }
}
