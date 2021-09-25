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

        public bool lagre(Bestill b)
        {
            Bestill bestill = new Bestill(b.fornavn, b.etternavn, b.epost, b.telefon, b.avreiseDato.Date, b.returDato.Date, b.strekningID);
            Bestilling nyBestill = new Bestilling(b.fornavn, b.etternavn, b.epost, b.telefon, b.avreiseDato.Date, b.returDato);

            var finnStrekningID = _DB.Strekninger.Find(b.strekningID);
            nyBestill.strekningID = finnStrekningID;

            // lagre ny bestilling
            _DB.Bestillinger.Add(nyBestill);
            _DB.SaveChanges();

            return true;
        }

        // hent alle bestillinger
        public List<Bestill> hentAlle()
        {
            List<Bestill> result = _DB.Bestillinger.Select(k => new Bestill
            {
                id = k.id,
                fornavn = k.fornavn,
                etternavn = k.etternavn,
                telefon = k.telefon,
                epost = k.epost,
                formatAvreise = k.avreiseDato.ToString("dd.MM.yyyy"),
                formatRetur= k.returDato.Date.ToString("dd.MM.yyyy"),
                strekning = k.strekningID.strekning,
                pris = k.strekningID.pris
            }).ToList();

            return result;
        }

        // hent kvittering (siste bestilling)
        public Bestill hentKvittering()
        {
            Bestill b = _DB.Bestillinger.Select(k => new Bestill
            {
                id = k.id,
                fornavn = k.fornavn,
                etternavn = k.etternavn,
                telefon = k.telefon,
                epost = k.epost,
                formatAvreise = k.avreiseDato.ToString("dd.MM.yyyy"),
                formatRetur = k.returDato.Date.ToString("dd.MM.yyyy"),
                strekning = k.strekningID.strekning,
                pris = k.strekningID.pris
            }).OrderBy(b => b.id).Last();

            return b;
        }
    }
}
