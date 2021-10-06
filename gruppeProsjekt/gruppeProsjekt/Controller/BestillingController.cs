using gruppeProsjekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        private ILogger<BestillingController> _log;
        
        public BestillingController(DB db, ILogger<BestillingController> log)
        {
            _DB = db;
            _log = log;
        }
        
        // lagre bestillinger
        public async Task<ActionResult> lagre(Bestill b) {

            if (ModelState.IsValid) // Hvis regex er godkjent, så er modellen godkjent
            {
                Bestilling nyBestill = new Bestilling(b.fornavn, b.etternavn, b.epost, b.telefon, b.avreiseDato.Date, b.returDato);

                var finnStrekningID = _DB.Strekninger.Find(b.strekningID);
                nyBestill.strekningID = finnStrekningID;

                try
                {
                    // lagre ny bestilling
                    _DB.Bestillinger.Add(nyBestill);
                    await _DB.SaveChangesAsync();
                    _log.LogInformation("Bestilling lagret");
                    return Ok("Bestilling lagret");
                }
                catch
                {
                    // feil i database lagring
                    _log.LogInformation("Database feil. Kunne ikke lagre bestilling.");
                    return BadRequest("Bestillingen kunne ikke lagres");
                }
            }
            else
            {
                // input valideringsfeil
                _log.LogInformation("Feil i inputvalidering");
                return BadRequest("Feil i inputvalidering");
                 
             }
        }

        // hent alle bestillinger
        public async Task<List<Bestill>> hentAlle(int sort)
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

            try
            {
                // async tolist
                List<Bestill> bestillinger = await alle.Select(k => new Bestill
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
                }).ToListAsync();

                return bestillinger;
            }
            catch
            {
                // feil
                return null;
            }
        }

        // hent kvittering (siste bestilling)
        public async Task<Bestill> hentKvittering()
        {
            try
            {
                // hent siste bestilling
                Bestill b = await _DB.Bestillinger.Select(k => new Bestill
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
                }).OrderBy(b => b.id).LastAsync();

                return b;
            }
            catch
            {
                // feil
                return null;
            }
            
        }
    }
}
