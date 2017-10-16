using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desire.WebAPI.Models.Atributos
{
    public class ForcaModel
    {
        [Key]
        public int pk_pts_for { get; set; }
        public char classe_for { get; set; }
        public int nv_for { get; set; }
        public decimal ap_for { get; set; }
        public int potencia_vl_for { get; set; }
        public int potencia_mg_for { get; set; }
        public decimal golpe_for { get; set; }
        public decimal dureza_for { get; set; }
        public int vigor_vl_for { get; set; }
        public int vigor_mg_for { get; set; }
        public int carga_vl_for { get; set; }
        public int carga_mg_for { get; set; }
        public int pct_vl_for { get; set; }
        public int pct_mg_for { get; set; }
    }
}
