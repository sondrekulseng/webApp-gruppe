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

        public void lagre(Bestill b)
        {
            Bestill bestill = new Bestill(b.fornavn, b.etternavn, b.epost, b.telefon, b.avreiseDato, b.strekningID);
            Bestilling nyBestill = new Bestilling(b.fornavn, b.etternavn, b.epost, b.telefon, b.avreiseDato);

            var finnStrekningID = _DB.Strekninger.Find(b.strekningID);
            nyBestill.strekningID = finnStrekningID;

            _DB.Bestillinger.Add(nyBestill);
            _DB.SaveChanges();
        }
    }
}
