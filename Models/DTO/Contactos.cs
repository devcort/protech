using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proptech.Models.DTO
{
    public class Contactos
    {
        [Display(Name = "id_contactos")]
        public int id_contactos { get; set; }

        [Display(Name = "nombre")]
        public string nombre { get; set; }

        [Display(Name = "telefono")]
        public string telefono { get; set; }

        [Display(Name = "email")]
        public string email { get; set; }

        [Display(Name = "clasificacion")]
        public string clasificacion { get; set; }

        [Display(Name = "direccion")]
        public string direccion { get; set; }
    }
}