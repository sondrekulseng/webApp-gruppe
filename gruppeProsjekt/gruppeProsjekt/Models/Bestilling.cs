using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gruppeProsjekt.Models
{
    public class Bestilling
    {
        public int antall { get; set; }
        public Billett billett { get; set; }
        public DateTime date { get; set; }
    }
}
