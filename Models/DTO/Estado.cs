using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proptech.Models.DTO
{
    public class Estado
    {
        [Display(Name = "id_estado")]
        public int id_estado { get; set; }

        [Display(Name = "nombre_estado")]
        public string nombre_estado { get; set; }

        [Display(Name = "id_pais")]
        public string id_pais { get; set; }
    }
}