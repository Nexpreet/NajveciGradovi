using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajveciGradovi {
    internal class Grad {

        public string Naziv { get; set; }
        public int Populacija { get; set; }
       

        public Grad(string naziv, int populacija) {
            Naziv = naziv;
            Populacija = populacija;
          
        }

        public override string ToString() {
            return "Grad: " + Naziv + " Stanovnici: " + Populacija;
        }

    }
}