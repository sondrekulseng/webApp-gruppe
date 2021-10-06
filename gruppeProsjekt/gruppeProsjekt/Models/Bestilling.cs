using System;
using System.ComponentModel.DataAnnotations;

namespace gruppeProsjekt.Models
{
    public class Bestilling
    {
        public Bestilling()
        {
        }

        public Bestilling(string fornavn, string etternavn, string epost, string telefon, DateTime avreiseDato, DateTime returDato)
        {
            this.fornavn = fornavn;
            this.etternavn = etternavn;
            this.epost = epost;
            this.telefon = telefon;
            this.avreiseDato = avreiseDato;
            this.returDato = returDato;
        }

        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string epost { get; set; }
        public string telefon { get; set; }
        public DateTime avreiseDato { get; set; }
        public DateTime returDato { get; set; }
        public virtual Strekning strekningID { get; set; }
    }

    public class Bestill
    {
        public Bestill()
        {
        }

        public Bestill(string fornavn, string etternavn, string epost, string telefon, DateTime avreiseDato, DateTime returDato, int strekningID)
        {
            this.fornavn = fornavn;
            this.etternavn = etternavn;
            this.epost = epost;
            this.telefon = telefon;
            this.avreiseDato = avreiseDato;
            this.returDato = returDato;
            this.strekningID = strekningID;
        }

        public int id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ]+$")]
        public string fornavn { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ]+$")]
        public string etternavn { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9æøåÆØÅ_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
        public string epost { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public string telefon { get; set; }
        public DateTime avreiseDato { get; set; }
        public DateTime returDato { get; set; }
        public string formatAvreise { get; set; }
        public string formatRetur { get; set; }
        public int strekningID { get; set; }
        public string strekning { get; set; }
        public double pris { get; set; }
    }
}
