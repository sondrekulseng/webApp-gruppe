using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gruppeProsjekt.Models
{
    public class Strekning
    {
        public Strekning (string strekning, double pris)
        {
            this.strekning = strekning;
            this.pris = pris;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int strekningID { get; set; }
        public string strekning { get; set; }
        public double pris { get; set; }
    }
}
