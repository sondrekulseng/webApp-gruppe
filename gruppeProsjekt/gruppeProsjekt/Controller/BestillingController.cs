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
            Bestill bestill = new Bestill(b.fornavn, b.etternavn, b.epost, b.telefon, b.avreiseDato.Date, b.strekningID);
            Bestilling nyBestill = new Bestilling(b.fornavn, b.etternavn, b.epost, b.telefon, b.avreiseDato.Date);

            var finnStrekningID = _DB.Strekninger.Find(b.strekningID);
            nyBestill.strekningID = finnStrekningID;

            _DB.Bestillinger.Add(nyBestill);
            _DB.SaveChanges();
        }

        public List<Bestill> hentAlle()
        {
            List<Bestill> result = _DB.Bestillinger.Select(k => new Bestill
            {
                id = k.id,
                fornavn = k.fornavn,
                etternavn = k.etternavn,
                telefon = k.telefon,
                epost = k.epost,
                avreiseDato = k.avreiseDato.Date,
                strekning = k.strekningID.strekning,
                pris = k.strekningID.pris
            }).ToList();

            return result;
        }
    }
}
