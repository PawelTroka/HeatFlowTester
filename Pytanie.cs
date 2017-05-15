using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrzepływCiepłaTester
{
    class Pytanie
    {
        public Pytanie() {}

        public Pytanie(String tresc, List<String> odpowiedzi, char poprawna)
        {
            this.Tresc = tresc;
            this.Odpowiedzi = odpowiedzi;
            this.PoprawnaOdpowiedz = poprawna;
        }
        public String Tresc { set; get; }
        public List<String> Odpowiedzi { set; get; }
        public char PoprawnaOdpowiedz{get; set;}
    }
}
