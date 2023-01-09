using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
//using System.Diagnostics;

namespace Borelli_Autobus {
    public class Autobus {
        private string _numTelaio, _targa, _azienda;
        private int _passMax, _pass;
        private bool _fermo, _inDeposito;
        //costruttore
        public Autobus(string nTelaio, string targ, string aziend, int passMax) {
            this.NumeroTelaio = nTelaio;
            this.Targa = targ;
            this.Azienda = aziend;
            this.PasseggeriMax = passMax;
            this.Fermo = true;
            this.InDeposito = false;
            this.Passeggeri = 0;
        }
        public Autobus() {

        }
        //funzioni specifiche
        public void Partenza() {
            if (this.Fermo) {
                this.Fermo = false;
                this.InDeposito = false; //assumo che se parto lo tolgo dal deposito
            } else {
                throw new Exception("Il bus è già in movimento");
            }
        }
        public void SalitaPasseggeri(int pass) {
            if (this.Fermo && !this.InDeposito) {
                //Debug.WriteLine($"PASS: {pass}");
                this.Passeggeri += pass;
            } else {
                throw new Exception("Non si possono far salire passeggere se il bus è in movimento o se è in deposito");
            }
        }
        public void Fermata() {
            if (!this.Fermo) {
                this.Fermo = true;
            } else {
                throw new Exception("Il bus è già fermo");
            }
        }
        public void DiscesaPasseggeri(int pass) {
            if (this.Fermo) {
                this.Passeggeri -= pass;
            } else {
                throw new Exception("Non si possono far scendere passeggere se il bus è in movimento");
            }
        }
        public void SpostaPasseggeri(Autobus a) {
            if (a != null) {
                if (this.Fermo && a.Fermo) {
                    a.SalitaPasseggeri(this.Passeggeri);
                    DiscesaPasseggeri(this.Passeggeri);
                } else {
                    throw new Exception("Entrambi i bus devono essere fermi per eseguire lo scambio");
                }

            } else {
                throw new Exception("Inserire un bus valido");
            }
        }
        public void Deposita() {
            Fermata();
            DiscesaPasseggeri(this.Passeggeri);
            this.InDeposito = true;
        }
        //funzioni standard
        public override string ToString() {
            return $"{this.NumeroTelaio};{this.Targa};{this.Azienda};{this.PasseggeriMax}";
        }
        public bool Equals(Autobus a) {
            if (a == null) {
                return false;
            } else if (a == this) {
                return true;
            } else {
                return (a.Targa == this.Targa);
            }
        }
        public Autobus Clone() {
            return new Autobus(this);
        }
        protected Autobus(Autobus a) : this(a.NumeroTelaio, a.Targa, a.Azienda, a.PasseggeriMax) {
        }
        //parte properties
        public string NumeroTelaio {
            get {
                return _numTelaio;
            }
            private set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    _numTelaio = value.ToUpper();
                } else {
                    throw new Exception("Inseire un numero telaio valido");
                }
            }
        }
        public string Targa {
            get {
                return _targa;
            }
            private set {
                Regex rx = new Regex("^[A-Z]{2}[0-9]{3}[A-Z]{2}");
                if (rx.IsMatch(value.ToUpper())) {
                    _targa = value.ToUpper();
                } else {
                    throw new Exception("Inserire una targa valida: AA000AA");
                }
            }
        }
        public string Azienda {
            get {
                return _azienda;
            }
            private set {
                if (!String.IsNullOrEmpty(value)) {
                    _azienda = value.ToUpper();
                } else {
                    throw new Exception("Inserire un'azienda valida");
                }
            }
        }
        public int PasseggeriMax {
            get {
                return _passMax;
            }
            private set {
                if (value > 0) {
                    _passMax = value;
                } else {
                    throw new Exception("Inserire un valore maggiore di 0");
                }
            }
        }
        public bool Fermo {
            get {
                return _fermo;
            }
            set {
                _fermo = value;
            }
        }
        public int Passeggeri {
            get {
                return _pass;
            }
            set {
                //Debug.WriteLine($"PASSEGGERI: {_pass}\tPASS MAX: {PasseggeriMax}\tVALUE: {value}");
                if (value >= 0 && value <= this.PasseggeriMax) {
                    _pass = value;
                } else {
                    throw new Exception("Capienza massima raggiunta o tentativo di scendere sotto 0");
                }
            }
        }
        public bool InDeposito {
            get {
                return _inDeposito;
            }
            set {
                _inDeposito = value;
            }
        }
    }
}
