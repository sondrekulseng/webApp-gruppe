using gruppeProsjekt.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gruppeProsjekt.Controller
{
    [Route("[controller]/[action]")]
    public class BestillingController : ControllerBase
    {
        private DB _DB;

        public BestillingController(DB db)
        {
            _DB = db;
        }

        public void lagre(Bestilling b)
        {
            Bestilling bestill = new Bestilling(b.fornavn, b.etternavn, b.epost, b.telefon, b.avreiseDato);

            _DB.Bestillinger.Add(bestill);
            _DB.SaveChanges();
        }
    }
}
