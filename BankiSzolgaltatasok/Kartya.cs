using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class Kartya : BankiSzolgaltatas
    {
        public Szamla MogottesSzamla { get; }
        public string KartyaSzam { get; }

        public Kartya(Tulajdonos tulajdonos, Szamla mogottesszamla, string kartyaszam) : base(tulajdonos)
        {
            MogottesSzamla = mogottesszamla;
            KartyaSzam = kartyaszam;
        }

        public bool Vasarlas(int összeg)
        {
            if (MogottesSzamla.Kivesz(összeg))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
