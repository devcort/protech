using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proptech.Models.DTO
{
    public class Comunicacion
    {
        [Display(Name = "id_comunicacion")]
        public int id_comunicacion { get; set; }

        [Display(Name = "id_propiedad")]
        public int id_propiedad { get; set; }

        [Display(Name = "asunto")]
        public string asunto { get; set; }

        [Display(Name = "persona_gestor")]
        public string persona_gestor { get; set; }

        [Display(Name = "nivel_interes")]
        public int nivel_interes { get; set; }

        [Display(Name = "fecha")]
        public DateTime fecha { get; set; }

        [Display(Name = "id_contactos")]
        public int id_contactos { get; set; }
    }
}