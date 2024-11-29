using NajveciGradovi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajveciGradovi {
    internal class Program {
        static void Main(string[] args) {

            // List<Region> regioni = UnesiRegione();
            // UnesiGradove(regioni);

            List<Region> regioni = Podaci();

            IspisPodataka(regioni);

            List<Grad> listaGradova = ObjediniGradove(regioni);

            int brojNajvecihGradova = 5;
            //List<Grad> listaNajvecihGradova = ListaNajvecihGradova(listaGradova, brojNajvecihGradova);

            //IspisGradova(listaNajvecihGradova, $"Najvecih {brojNajvecihGradova} gradova");
            IspisGradova(ListaNajvecihGradova(regioni, brojNajvecihGradova), $"Najvecih {brojNajvecihGradova} gradova");


        }

        private static List<Region> UnesiRegione() {
            List<Region> regioni = new List<Region>();

            string prekid;
            string naziv;

            do {
                Console.Write("Unesite Region: ");
                naziv = Console.ReadLine();

                regioni.Add(new Region(naziv));


                Console.WriteLine();

                Console.Write("Da li zelite da dodate jos jedan region [da]/[ne]: ");
                prekid = Console.ReadLine();

                Console.WriteLine();

            } while (!prekid.ToLower().Equals("ne"));

            return regioni;
        }

        public static void UnesiGradove(List<Region> regioni) {



            string prekid = "da";
            string naziv;
            string region;
            int populacija;

            do {
                //Unos regiona
                Console.Write("Unesite region u kome se nalazi grad: ");
                region = Console.ReadLine();

                Region rg = PronadjiRegion(regioni, region);

                if (rg == null) {
                    Console.WriteLine("Region ne postoji! Unesite ponovo");
                    continue;
                }

                //Unos Gradova
                Console.Write("Unesite Grad: ");
                naziv = Console.ReadLine();

                //Unos Populacije
                Console.Write("Unesite Broj Stanovnika: ");
                populacija = int.Parse(Console.ReadLine());


                // Dodavanje novog grada u listu
                rg.Gradovi.Add(new Grad(naziv, populacija));



                Console.WriteLine();

                Console.Write("Da li zelite da dodate jos jedan grad [da]/[ne]: ");
                prekid = Console.ReadLine();

                Console.WriteLine();

            } while (!prekid.ToLower().Equals("ne"));
        }

        public static Region PronadjiRegion(List<Region> regioni, string naziv) {
            foreach (Region region in regioni) {

                if (region.Naziv.ToLower() == naziv.ToLower())
                    return region;
            }
            return null;
        }

        public static void IspisPodataka(List<Region> regioni) {
            foreach (Region region in regioni) {

                Console.WriteLine(region.ToString());

                foreach (Grad grad in region.Gradovi) {

                    Console.WriteLine(grad.ToString());
                }
                Console.WriteLine();
            }

        }

        static List<Grad> ObjediniGradove(List<Region> regioni) {

            List<Grad> gradovi = new List<Grad>();

            foreach (Region region in regioni) {
                gradovi.AddRange(region.Gradovi);
            }

            gradovi.Sort((b, a) => a.Populacija.CompareTo(b.Populacija));

            return gradovi;
        }


        static void IspisGradova(List<Grad> gradovi, string naslov) 
        {
            Console.WriteLine($"{naslov}");
            foreach (Grad grad in gradovi) 
                Console.WriteLine(grad.ToString());           
        }

        static List<Grad> ListaNajvecihGradova(List<Grad> gradovi, int brojNajvecihGradova) 
        {
            return gradovi.Take(brojNajvecihGradova).ToList();
        }

        static List<Grad> ListaNajvecihGradova(List<Region> regioni, int brojNajvecihGradova) 
        {
            return ListaNajvecihGradova(ObjediniGradove(regioni), brojNajvecihGradova);
        }

        static List<Region> Podaci() {
            List<Region> regioni = new List<Region>()
            {
                new Region("Centralna Srbija")
                {
                    Gradovi = new List<Grad>()
                    {
                        new Grad("Beograd", 1000000),
                        new Grad("Sopot", 24000),
                    }
                },
                new Region("Vojvodina")
                {
                    Gradovi = new List<Grad>()
                    {
                        new Grad("Novi Sad", 300000),
                        new Grad("Subotica", 40000),
                        new Grad("Pancevo", 30000),
                        new Grad("Stari Banovci", 4000),
                        new Grad("Novi Banovci", 2000),
                        new Grad("Belegis", 1000),
                    }
                },
                new Region("Kosovo")
                {
                    Gradovi = new List<Grad>()
                    {
                        new Grad("Kosovska Mitrovica", 35000),
                        new Grad("Pec", 12000),
                        new Grad("Djakovica", 16000),
                        new Grad("Prizren", 28000),
                        new Grad("Gracanica", 2100),
                        new Grad("Pristina", 250000),
                    }
                }
            };

            return regioni;
        }

    }
}