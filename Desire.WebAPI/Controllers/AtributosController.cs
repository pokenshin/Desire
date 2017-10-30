using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desire.Core;
using Desire.WebAPI.Models.Atributos;
using Desire.WebAPI.Data;
using Desire.Core.Util.Geradores;
using Microsoft.EntityFrameworkCore;

namespace Desire.WebAPI.Controllers
{
    public class AtributosController : Controller
    {
        // GET api/database/atributos/forca
        // Pega uma lista de atributos de força
        [HttpGet("api/database/atributos/forca")]
        [Produces("application/json", "application/xml")]
        public List<ForcaModel> ListForcas()
        {
            using (var context = new MySQLContext())
            {
                return context.t_atr_forca.ToList();
            }
        }

        // GET api/values/5
        [HttpGet("api/db/atributos/forca/{pts}")]
        public Forca Forca(int pts)
        {
            return null;
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
