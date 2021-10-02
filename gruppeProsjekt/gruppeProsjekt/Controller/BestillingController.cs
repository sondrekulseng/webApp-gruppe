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
        public List<Bestill> hentAlle(int sort)
        {

            var alle = _DB.Bestillinger.OrderBy(b => b.id);

            if (sort == 0)
            {
                // ID stigende
                alle = _DB.Bestillinger.OrderBy(b => b.id);
            }
            else if (sort == 1)
            {
                // ID synkende
                alle = _DB.Bestillinger.OrderByDescending(b => b.id);
            }
            else if (sort == 2)
            {
                // Avreise dato
                alle = _DB.Bestillinger.OrderBy(b => b.avreiseDato);
            }
            else if (sort == 3)
            {
                // Strekning alfabetisk
                alle = _DB.Bestillinger.OrderBy(b => b.strekningID.strekning);
            }
            else if (sort == 4)
            {

                // Fornavn alfabetisk
                alle = _DB.Bestillinger.OrderBy(b => b.fornavn);
            }
            else if (sort == 5)
            {

                // Etternavn alfabetisk
                alle = _DB.Bestillinger.OrderBy(b => b.etternavn);
            }

            return alle.Select(k => new Bestill
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
            }).ToList();


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
