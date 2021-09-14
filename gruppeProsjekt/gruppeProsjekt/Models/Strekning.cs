using System;
using System.Collections.Generic;
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

        public int id { get; set; }
        public string strekning { get; set; }
        public double pris { get; set; }
    }
}
