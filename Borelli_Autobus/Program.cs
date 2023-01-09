using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Autobus {
    internal class Program {
        static void Main(string[] args) {
            Autobus a = new Autobus("TELAIO", "FL719BJ", "ARRIVAITALIA", 169);
            Console.WriteLine($"PARTENZA BUS");
            a.Partenza();
            Console.WriteLine($"SALGONO 30 PASSEGGERI\tPRIMA LO FERMO");
            a.Fermata();
            a.SalitaPasseggeri(20);
            Console.WriteLine($"PASSEGGERI: {a.Passeggeri}");
            Console.ReadKey();
            Console.WriteLine($"\bSALGONO 130 PASSEGGERI");
            a.SalitaPasseggeri(130);
            Console.WriteLine($"PASSEGGERI: {a.Passeggeri}");
            Console.ReadKey();
        }
    }
}
