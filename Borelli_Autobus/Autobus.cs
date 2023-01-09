using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Borelli_Autobus {
    public class Autobus {
        private string _numTelaio, _targa, _azienda;
        private int _passMax;
        //costruttore
        public Autobus(string nTel, string targ, string aziend, int passMax) {
            this.NumeroTelaio = nTel;
            this.Targa = targ;
            this.Azienda = aziend;
            this.PasseggeriMax = passMax;
        }
        public Autobus() {

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
    }
}
