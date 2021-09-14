using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gruppeProsjekt.Models
{
    public class Bestilling
    {
        public Bestilling()
        {
        }

        public Bestilling(string fornavn, string etternavn, string epost, string telefon, DateTime avreiseDato)
        {
            this.fornavn = fornavn;
            this.etternavn = etternavn;
            this.epost = epost;
            this.telefon = telefon;
            this.avreiseDato = avreiseDato;
        }

        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string epost { get; set; }
        public string telefon { get; set; }
        public DateTime avreiseDato { get; set; }
        public virtual Strekning strekningID { get; set; }
    }

    public class Bestill
    {
        public Bestill()
        {
        }

        public Bestill(string fornavn, string etternavn, string epost, string telefon, DateTime avreiseDato, int strekningID)
        {
            this.fornavn = fornavn;
            this.etternavn = etternavn;
            this.epost = epost;
            this.telefon = telefon;
            this.avreiseDato = avreiseDato;
            this.strekningID = strekningID;
        }

        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string epost { get; set; }
        public string telefon { get; set; }
        public DateTime avreiseDato { get; set; }
        public int strekningID { get; set; }
        public string strekning { get; set; }
        public double pris { get; set; }
    }
}
