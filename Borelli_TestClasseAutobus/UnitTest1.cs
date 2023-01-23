using Borelli_Autobus;
namespace Borelli_TestClasseAutobus {
    public class UnitTest1 {
        [Fact]
        public void TestDatiValidi() {
            Autobus a;
            Assert.Throws<Exception>(() => (a = new Autobus("aaaa", "FLPPP45", "Azienza", 89)));
        }

        [Fact]
        public void TestDatiValidi2() {
            Autobus a;
            Assert.Throws<Exception>(() => (a = new Autobus("aaaa", "GM820CK", "Azienza", -5)));
        }

        [Fact]
        public void AutobusSalitaDiscesa() {
            Autobus a = new Autobus("aaaa", "GM820CK", "Azienza", 50);
            a.Fermata();
            a.SalitaPasseggeri(49);
            a.DiscesaPasseggeri(24);
            a.SalitaPasseggeri(10);
            a.DiscesaPasseggeri(34);

            Assert.True(a.Passeggeri == 1);
        }

        [Fact]
        public void AutobusInMovimento() {
            Autobus a = new Autobus("aaaa", "GM820CK", "Azienza", 50);
            a.Partenza();
            Assert.Throws<Exception>(() => a.SalitaPasseggeri(50));
        }

        [Fact]
        public void PasseggeriInNegativo() {
            Autobus a = new Autobus("aaaa", "GM820CK", "Azienza", 50);
            a.Fermata();
            Assert.Throws<Exception>(() => a.SalitaPasseggeri(-50));
        }

        [Fact]
        public void ScambioAutobus() {
            Autobus a = new Autobus("aaaa", "GM820CK", "Azienza", 50);
            Autobus b = new Autobus("bbbb", "FL820CK", "Azienza2", 100);
            a.Fermata();
            b.Fermata();

            a.SalitaPasseggeri(45);
            a.SpostaPasseggeri(b);

            Assert.True(a.Passeggeri == 0 && b.Passeggeri == 45);
        }

        [Fact]
        public void ScambioAutobusInMovimento() {
            Autobus a = new Autobus("aaaa", "GM820CK", "Azienza", 50);
            Autobus b = new Autobus("bbbb", "FL820CK", "Azienza2", 100);
            a.Fermata();
            b.Fermata();

            a.SalitaPasseggeri(45);
            a.Partenza();

            Assert.Throws<Exception>(() => a.SpostaPasseggeri(b));
        }

        [Fact]
        public void ScambioAutobusConTroppiPasseggeri() {
            Autobus a = new Autobus("aaaa", "GM820CK", "Azienza", 50);
            Autobus b = new Autobus("bbbb", "FL820CK", "Azienza2", 25);
            a.Fermata();
            b.Fermata();

            a.SalitaPasseggeri(45);

            Assert.Throws<Exception>(() => a.SpostaPasseggeri(b));
        }
    }
}