using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proptech.Models.DTO
{
    public class Usuario
    {

        [Display(Name = "id_usuario")]
        public int id_usuario { get; set; }


        [Display(Name = "nombre")]
        public string nombre { get; set; }


        [Display(Name = "correo")]
        public string correo { get; set; }


        [Display(Name = "contraseña")]
        public string contraseña { get; set; }

    }
}