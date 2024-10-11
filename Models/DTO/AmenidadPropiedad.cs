using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proptech.Models.DTO
{
    public class AmenidadPropiedad
    {
        [Display(Name = "id_amenidades_propiedad")]
        public int id_amenidades_propiedad { get; set; }

        [Display(Name = "id_propiedad")]
        public string id_propiedad { get; set; }

        [Display(Name = "nombre")]
        public string nombre { get; set; }

    }
}