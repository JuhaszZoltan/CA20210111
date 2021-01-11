using System;

namespace CA20210111
{
    class Csapat
    {
        public string Orszag { get; set; }
        public int ReszvetelSzam { get; set; }
        public int ElsoReszvetel { get; set; }
        public int LegutobbiReszvetel { get; set; }
        public string LejobbEredmeny { get; set; }
        public int ElsoRszvetelOtaElteltEv => DateTime.Now.Year - ElsoReszvetel;

        public Csapat(string r)
        {
            try
            {
                var a = r.Split(';');
                Orszag = a[0];
                ReszvetelSzam = int.Parse(a[1]);
                ElsoReszvetel = int.Parse(a[2]);
                LegutobbiReszvetel = int.Parse(a[3]);
                LejobbEredmeny = a[4];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"\n\nAdatfeldolgozási hiba a következő sorban:\n\n{r}");
                throw;
            }
        }
    }
}
