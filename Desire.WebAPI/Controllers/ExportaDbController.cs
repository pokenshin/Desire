using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desire.WebAPI.Controllers
{
    public class ExportaDbController : Controller
    {
        [HttpGet("api/database/exportadb")]

        public string ExportaDb()
        {
            string sql = "Jonas";

            return sql;
        }

        //Cria sql de importação da tabela t_atr_forca
    }
}