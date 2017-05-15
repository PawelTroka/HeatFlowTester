using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PrzepływCiepłaTester
{
    class Test
    {
        public Test(String filePath = @"data/baza.dat")
        {
            random = new Random();
            pytania = new List<Pytanie>();
            pytanie = new Pytanie();
            wczytajBaze(filePath);
            
        }

        public bool udzielamOdpowiedzi(char odp)
        {
            if (odp==pytanie.PoprawnaOdpowiedz)
            {
                liczbaPoprawnychOdpowiedzi++;
                liczbaPytan++;
                return true;
            }
            else
            {
                liczbaPytan++;
                return false;
            }
        }

        public String pokazWynik()
        {
            return "Twój wynik to:" + (100) * ((double)liczbaPoprawnychOdpowiedzi / (double)liczbaPytan) + "%";
        }


        public double getWynik()
        {
            return (100) * ((double)liczbaPoprawnychOdpowiedzi / (double)liczbaPytan);
        }

        public List<String> dajOdpowiedzi()
        {
            return pytanie.Odpowiedzi;
        }

        public void losujPytanie()
        {
            pytanie = pytania[random.Next(pytania.Count)];
        }

        public String dajPytanie()
        {
            int index = random.Next(pytania.Count);
            pytanie = pytania[index];
            return pytanie.Tresc;
        }

        public int getLiczbaPytan()
        {
            return pytania.Count;
        }

        private void wczytajBaze(String filePath)
        {
            String line;

            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    while ((line = file.ReadLine()) != null)
                    {
                        String strPytanie=line;
                        int liczbaOdpowiedzi=int.Parse(file.ReadLine());
                        List<String> listOdpowiedzi=new List<String>();
                        for(int i=0;i<liczbaOdpowiedzi;i++)
                            listOdpowiedzi.Add(file.ReadLine());
                        int poprawnaOdpowiedz='a'-1+int.Parse(file.ReadLine());
                        pytania.Add(new Pytanie(strPytanie, listOdpowiedzi, (char)poprawnaOdpowiedz));
                    }

                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
        }

        private uint liczbaPoprawnychOdpowiedzi;
        private uint liczbaPytan;
        private List<Pytanie> pytania;
        private Pytanie pytanie;
        private Random random;
    }
}
