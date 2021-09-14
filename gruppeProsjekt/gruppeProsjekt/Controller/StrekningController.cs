using gruppeProsjekt.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Strekning> hent()
        {
            return _DB.Strekninger.ToList();
        }
    }
}
