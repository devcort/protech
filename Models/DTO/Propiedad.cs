using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proptech.Models.DTO
{
    public class Propiedad
    {

        [Display(Name = "id_propiedad")]
        public int id_propiedad { get; set; }

        [Display(Name = "nombre")]
        public string nombre { get; set; }

        [Display(Name = "direccion")]
        public string direccion { get; set; }

        [Display(Name = "terreno")]
        public float terreno { get; set; }

        [Display(Name = "ciudad")]
        public int ciudad { get; set; }

        [Display(Name = "num_cuartos")]
        public int num_cuartos { get; set; }

        [Display(Name = "num_baños")]
        public int num_baños { get; set; }

        [Display(Name = "num_pisos")]
        public int num_pisos { get; set; }

    }
}