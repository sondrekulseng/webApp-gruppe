using gruppeProsjekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gruppeProsjekt.Controller
{
    [Route("[controller]/[action]")]
    public class StrekningController : ControllerBase
    {
        private DB _DB;

        public StrekningController(DB db)
        {
            _DB = db;
        }

        public async Task<List<Strekning>> hent()
        {
            try
            {
                // returner strekninger
                return await _DB.Strekninger.ToListAsync();
            }
            catch
            {
                // feil
                return null;
            }
            
        }
    }
}
