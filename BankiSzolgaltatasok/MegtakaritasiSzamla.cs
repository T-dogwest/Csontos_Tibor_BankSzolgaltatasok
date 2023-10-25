using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class MegtakaritasiSzamla : Szamla
    {
        public double Kamat { get; set; }
        public static double alapKamat { get; } = 1.1;

        public MegtakaritasiSzamla(Tulajdonos tulajdonos) : base(tulajdonos)
        {
            Kamat = alapKamat;
        }

        public override bool Kivesz(int osszeg)
        {
            if (AktualisEgyenleg - osszeg >= 0)
            {
                this.aktualisEgyenleg -= osszeg;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void KamatJovairas()
        {
            this.aktualisEgyenleg *= Kamat;
        }
    }
}
