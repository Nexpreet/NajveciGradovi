using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajveciGradovi {
    internal class Region : Object
    {

        public  string Naziv { get; set; }

        public List<Grad> Gradovi { get; set; }

        public Region(string naziv) 
        {
            Naziv = naziv;
            Gradovi = new List<Grad>();
        }

        public override string ToString()
        { 
            return Naziv + " ima " + Gradovi.Count + " gradova";
        }
    }
}
