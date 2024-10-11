using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proptech.Models.DTO
{
    public class PropiedadContactos
    {
        [Display(Name = "id_propiedad_contactos")]
        public int id_propiedad_contactos { get; set; }


        [Display(Name = "id_contactos")]
        public int id_contactos { get; set; }

        [Display(Name = "id_propiedad")]
        public int id_propiedad { get; set; }
    }
}