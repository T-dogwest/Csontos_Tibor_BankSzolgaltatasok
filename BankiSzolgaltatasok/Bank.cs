using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class Bank
    {
        private List<Szamla> szamlak = new List<Szamla>();

        public Szamla SzamlaNyitas(Tulajdonos tulajdonos, double hitelkeret)
        {
            if (hitelkeret < 0)
            {
                throw new ArgumentException("A hitelkeret nem lehet negatív érték.");
            }

            Szamla ujSzamla;
            if (hitelkeret > 0)
            {
                ujSzamla = new HitelSzamla(tulajdonos, hitelkeret);
            }
            else
            {
                ujSzamla = new MegtakaritasiSzamla(tulajdonos);
            }

            szamlak.Add(ujSzamla);
            return ujSzamla;
        }

        public double GetOsszEgyenleg(Tulajdonos tulajdonos)
        {
            double osszEgyenleg = 0;
            foreach (Szamla szamla in szamlak)
            {
                if (szamla.Tulajdonos == tulajdonos)
                {
                    osszEgyenleg += szamla.AktualisEgyenleg;
                }
            }
            return osszEgyenleg;
        }

        public Szamla GetLegnagyobbEgyenleguSzamla(Tulajdonos tulajdonos)
        {
            Szamla legnagyobbEgyenleguSzamla = null;
            double legnagyobbEgyenleg = 0;

            foreach (Szamla szamla in szamlak)
            {
                if (szamla.Tulajdonos == tulajdonos && szamla.AktualisEgyenleg > legnagyobbEgyenleg)
                {
                    legnagyobbEgyenleg = szamla.AktualisEgyenleg;
                    legnagyobbEgyenleguSzamla = szamla;
                }
            }
            return legnagyobbEgyenleguSzamla;
        }

        public double OsszHitelkeret
        {
            get
            {
                double osszHitelkeret = 0;
                foreach (Szamla szamla in szamlak)
                {
                    if (szamla is HitelSzamla)
                    {
                        osszHitelkeret += ((HitelSzamla)szamla).HitelKeret;
                    }
                }
                return osszHitelkeret;
            }
        }
    }
}
