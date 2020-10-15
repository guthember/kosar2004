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

    static void Main(string[] args)
    {
      MasodikFeladat();
      HarmadikFeladat();

      Console.ReadLine();
    }
  }
}
