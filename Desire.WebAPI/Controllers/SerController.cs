using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desire.Core;
using Desire.Core.Util.Geradores;

namespace Desire.WebAPI.Controllers
{
    public class SerController : Controller
    {
        // GET api/ser
        [HttpGet("api/ser.{format}"), FormatFilter]
        [Produces("application/json", "application/xml")]
        public Ser Get()
        {
            Random rnd = new Random();
            GeradorSer gerador = new GeradorSer();
            return gerador.Gerar(rnd);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
