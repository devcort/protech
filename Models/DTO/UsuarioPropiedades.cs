using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proptech.Models.DTO
{
    public class UsuarioPropiedades
    {
        [Display(Name = "id_usuario_propiedad")]
        public int id_usuaio_propiedad { get; set; }

        [Display(Name = "id_usuario")]
        public int id_usuario { get; set; }

        [Display(Name = "id_propiedad")]
        public int id_propiedad { get; set; }


    }
}