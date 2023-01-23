using Energia;

namespace Borelli_TestBolletteMosconi {
    public class UnitTest1 {
        [Fact]
        public void CostruttoreEccezioni() {//errore perchè dovrebbe dare eccezione, così non si sa cosa setti
            BollettaEnergetica b2;
            Assert.Throws<Exception>(() => (b2 = new BollettaEnergetica("ID", 8.5, 9, 30, 5)));
            //Assert.True(b2.Id == "ID");
        }


        [Fact]
        public void CostruttoreEccezioniPositivi() {//errore perchè dovrebbe dare eccezione, così non si sa cosa setti
            BollettaEnergetica b2;
            Assert.Throws<Exception>(() => (b2 = new BollettaEnergetica("ID0000", -8.5, -9, 30, -5)));
        }

        [Fact]
        public void CostruttoreEccezioniSpaziVuoti() {//errore perchè dovrebbe dare eccezione, così non si sa cosa setti
            BollettaEnergetica b2;
            Assert.Throws<Exception>(() => (b2 = new BollettaEnergetica("", -8.5, -9, 30, -5)));
        }

        [Fact]
        public void CodiceGenerale() {//controllo che i due codici siano diversi
            BollettaEnergetica b2 = new BollettaEnergetica();
            string uwu = b2.CodiceGenerale();

            BollettaEnergetica b3 = new BollettaEnergetica();
            string uwu1 = b3.CodiceGenerale();

            Assert.False(uwu == uwu1);
        }

        [Fact]
        public void CalcoloTasse() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            //b2.Tasse = 1; se toglo il commento funziona perchè setta il valore di tasse quando fccio il set ma lo fa INDIPENDENTEMEMNTE dal value fa un calvolo suo. Se io non lo setto mai non si autosetterà mai da solo
            Assert.True(b2.Tasse == ((5 + 10) * 20));
        }

        [Fact]
        public void CalcoloPrezzoTot() { //non va perchè Tasse è empre uguale a 0 finchè non lo setto una prima volta che poi si autosetta
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            Assert.True(b2.Tasse == (((5 + 10) * 20)) * 2);
        }

        [Fact]
        public void TestIncrementaUnEnergetica() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            b2.IncrementaUnitaEnergetica(100);
            Assert.True(b2.Prezunita == 5 * 2);
        }

        [Fact]
        public void TestIncrementaDistr() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            b2.IncrementaUnitaDistribuzione(100);
            Assert.True(b2.Prezdistribuzione == 10 * 2);
        }

        [Fact]
        public void ConfrontaBolletteConNull() { //dovrebbe dare eccezione
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            Assert.Throws<Exception>(() => b2.Confronto(null));
        }

        [Fact]
        public void ConfrontaBolletteConStessaBolletta() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            Assert.Throws<Exception>(() => b2.Confronto(b2));
        }

        [Fact]
        public void ConfrontaBollette() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            BollettaEnergetica b1 = new BollettaEnergetica("234567", 10, 20, 40, 100);
            string uwu = b2.Confronto(b1);
            string uwuB2 = b2.ToString();

            Assert.True(uwuB2 == uwu);
        }

        [Fact]
        public void EqualsDiClone() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            BollettaEnergetica b1 = b2.Clone();

            Assert.True(b1.Equals(b2));
        }

        [Fact]
        public void TestDecrementaDistr() { //andrebbe messo minore di 0 ma poi si sballa con i calcoli visto ch è negativo
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            b2.DecrementaUnitaDistribuzione(-100);
            Assert.True(b2.Prezdistribuzione == 0);
        }

        [Fact]
        public void TestModifica() { //andrebbe messo minore di 0 ma poi si sballa con i calcoli visto ch è negativo
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            b2.Modifica("456789", 10, 20, 40, 50);
            Assert.True(b2.Id == "456789");
        }

        [Fact]
        public void TestToString() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            Assert.True(b2.ToString() == $"Bolletta:{b2.Id};{b2.Prezunita};{b2.Prezdistribuzione};{b2.Consumo};300;{b2.Perctassa}"); //è 300 perchè ho fatto io il calcolo di default darebbe 0 ed è sbagliato
        }

        [Fact]
        public void TestClone() {
            BollettaEnergetica b2 = new BollettaEnergetica("123456", 5, 10, 20, 100);
            BollettaEnergetica b1 = b2.Clone();

            Assert.True(b1 != null);
        }
    }
}