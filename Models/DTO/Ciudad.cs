using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proptech.Models.DTO
{
    public class Ciudad
    {
        [Display(Name = "id_ciudad")]
        public int id_ciudad { get; set; }

        [Display(Name = "nombre_ciudad")]
        public string nombre_ciudad { get; set; }

        [Display(Name = "id_estado")]
        public int id_estado { get; set; }

    }
}