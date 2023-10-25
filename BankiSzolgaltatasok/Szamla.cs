using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public abstract class Szamla : BankiSzolgaltatas
    {
        protected double aktualisEgyenleg;

        protected Szamla(Tulajdonos tulajdonos) : base(tulajdonos)
        {

            this.aktualisEgyenleg = 0.0;
        }

        public double AktualisEgyenleg { get => aktualisEgyenleg; }

        public void Befizet(double osszeg)
        {
            this.aktualisEgyenleg += Math.Abs(osszeg);
        }
        public abstract bool Kivesz(int osszeg);
        public Kartya UjKartya(string kartyaszam)
        {
            Kartya ujkartya = new Kartya(Tulajdonos, this, kartyaszam);
            return ujkartya;
        }

    }
}
