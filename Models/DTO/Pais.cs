using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proptech.Models.DTO
{
    public class Pais
    {
        [Display(Name = "id_pais")]
        public int id_pais { get; set; }

        [Display(Name = "nombre_pais")]
        public string nombre_pais { get; set; }

    }
}