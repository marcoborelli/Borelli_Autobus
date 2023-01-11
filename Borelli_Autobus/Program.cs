using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Autobus {
    internal class Program {
        static void Main(string[] args) {
            Autobus a = new Autobus("TELAIO", "FL719BJ", "ARRIVAITALIA", 169);
            Autobus b = new Autobus("TELAIO1", "Cd494dJ", "SABFASCHIFO", 100);
            Console.WriteLine($"PARTENZA BUS A CON 110 PASSEGGERI");
            a.SalitaPasseggeri(110);
            a.Fermata();
            b.Fermata();
            Console.WriteLine($"BUS A:\n\tPASS MAX: {a.PasseggeriMax}\n\tPASS ATT: {a.Passeggeri}");
            Console.WriteLine($"BUS B:\n\tPASS MAX: {b.PasseggeriMax}\n\tPASS ATT: {b.Passeggeri}");
            a.SpostaPasseggeri(b);
            Console.WriteLine($"BUS A:\n\tPASS MAX: {a.PasseggeriMax}\n\tPASS ATT: {a.Passeggeri}");
            Console.WriteLine($"BUS B:\n\tPASS MAX: {b.PasseggeriMax}\n\tPASS ATT: {b.Passeggeri}");
            Console.ReadKey();
        }
    }
}
