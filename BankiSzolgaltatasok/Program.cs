namespace BankiSzolgaltatasok
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Tulajdonos t1 = new Tulajdonos("Arany Janos");
            Tulajdonos t2 = new Tulajdonos("Telekei Pál");
           
            Bank bank = new Bank();
            Szamla szamla1 = bank.SzamlaNyitas(t1, 1000.0);
            Szamla szamla2 = bank.SzamlaNyitas(t2, 0.0);

            szamla1.Befizet(500.0);
            szamla2.Befizet(200.0);

            bool vasarlas1 = szamla1.Kivesz(300);
            bool vasarlas2 = szamla2.Kivesz(300);

            Console.WriteLine("Vásárlás 1: " + vasarlas1);
            Console.WriteLine("Vásárlás 2: " + vasarlas2);

            if (szamla2 is MegtakaritasiSzamla)
            {
                ((MegtakaritasiSzamla)szamla2).KamatJovairas();
            }

            double osszEgyenleg = bank.GetOsszEgyenleg(t1);
            Console.WriteLine("Összegyenleg: " + osszEgyenleg);

            Szamla legnagyobbEgyenleguSzamla = bank.GetLegnagyobbEgyenleguSzamla(t1);
            Console.WriteLine("Legnagyobb egyenlegű számla: " + legnagyobbEgyenleguSzamla.AktualisEgyenleg);

            double osszHitelkeret = bank.OsszHitelkeret;
            Console.WriteLine("Összhitelkeret: " + osszHitelkeret);
        }
    }
    
}