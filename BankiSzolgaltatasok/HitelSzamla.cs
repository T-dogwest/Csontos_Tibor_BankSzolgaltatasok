using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class HitelSzamla : Szamla
    {
        public double HitelKeret { get; }

        public HitelSzamla(Tulajdonos tulajdonos, double hitelkeret) : base(tulajdonos)
        {
            HitelKeret = Math.Abs(hitelkeret);
        }

        public override bool Kivesz(int osszeg)
        {
            if (aktualisEgyenleg + HitelKeret >= osszeg)
            {
                aktualisEgyenleg -= osszeg;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
