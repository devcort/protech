using Proptech.Models;
using Proptech.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Propiedad = Proptech.Models.DTO.Propiedad;

namespace Proptech.Controllers
{
    public class PropiedadController : Controller
    {
        // GET: Propiedad
        public ActionResult Index(string searchString, string sortOrder)
        {
            List<Propiedad> listPropiedad;

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                listPropiedad = context.Propiedad.Select(p => new Propiedad()
                {
                    id_propiedad = p.id_propiedad,
                    nombre = p.nombre,
                    direccion = p.direccion,
                    terreno = (float)p.terreno,
                    ciudad = (int)p.ciudad,
                    num_cuartos = (int)p.num_cuartos,
                    num_baños = (int)p.num_baños,
                    num_pisos = (int)p.num_pisos
                }).ToList();

                // Aplicar filtros de búsqueda si se proporciona un término de búsqueda
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower(); // Convertir a minúsculas para una búsqueda sin distinción entre mayúsculas y minúsculas
                    listPropiedad = listPropiedad.Where(p =>
                        p.nombre.ToLower().Contains(searchString) ||
                        p.direccion.ToLower().Contains(searchString) ||
                        p.ciudad.ToString().ToLower().Contains(searchString) // Asegúrate de que este filtro sea relevante para tu caso
                                                                             // Agrega más condiciones si es necesario
                    ).ToList();
                }

                // Aplicar ordenamiento
                switch (sortOrder)
                {
                    case "nombre_desc":
                        listPropiedad = listPropiedad.OrderByDescending(p => p.nombre).ToList();
                        break;
                    default:
                        listPropiedad = listPropiedad.OrderBy(p => p.nombre).ToList();
                        break;
                }
            }

            ViewBag.CurrentFilter = searchString; // Mantener el valor de búsqueda en la vista
            ViewBag.NombreSortParm = string.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";

            return View(listPropiedad);
        }


        // GET: Propiedad/Details/5
        public ActionResult Details(int id)
        {
            Propiedad propiedad;

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                propiedad = context.Propiedad.Where(p => p.id_propiedad == id)
                    .Select(p => new Propiedad()
                    {
                        id_propiedad = p.id_propiedad,
                        nombre = p.nombre,
                        direccion = p.direccion,
                        terreno = (float)p.terreno,
                        ciudad = (int)p.ciudad,
                        num_cuartos = (int)p.num_cuartos,
                        num_baños = (int)p.num_baños,
                        num_pisos = (int)p.num_pisos
                    }).FirstOrDefault();
            }

            if (propiedad == null)
            {
                return HttpNotFound();
            }

            return View(propiedad);
        }

        // GET: Propiedad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propiedad/Create
        [HttpPost]
        public ActionResult Create(Propiedad propiedadDto) // Usa el DTO como parámetro
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PropTechEntitiesDB context = new PropTechEntitiesDB())
                    {
                        var nuevaPropiedad = new Proptech.Models.Propiedad // Asegúrate de usar el modelo de entidad correcto
                        {
                            nombre = propiedadDto.nombre,
                            direccion = propiedadDto.direccion,
                            terreno = propiedadDto.terreno,
                            ciudad = propiedadDto.ciudad,
                            num_cuartos = propiedadDto.num_cuartos,
                            num_baños = propiedadDto.num_baños,
                            num_pisos = propiedadDto.num_pisos
                        };

                        context.Propiedad.Add(nuevaPropiedad); // Agrega la nueva propiedad a la base de datos
                        context.SaveChanges(); // Guarda los cambios
                    }

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                // Manejo de errores
            }

            return View(propiedadDto); // Vuelve a mostrar la vista de creación con el DTO
        }


        // GET: Propiedad/Edit/5
        public ActionResult Edit(int id)
        {
            Propiedad propiedad;

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                propiedad = context.Propiedad.Where(p => p.id_propiedad == id)
                    .Select(p => new Propiedad()
                    {
                        id_propiedad = p.id_propiedad,
                        nombre = p.nombre,
                        direccion = p.direccion,
                        terreno = (float)p.terreno,
                        ciudad = (int)p.ciudad,
                        num_cuartos = (int)p.num_cuartos,
                        num_baños = (int)p.num_baños,
                        num_pisos = (int)p.num_pisos
                    }).FirstOrDefault();
            }

            if (propiedad == null)
            {
                return HttpNotFound();
            }

            return View(propiedad);
        }

        // POST: Propiedad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Propiedad propiedad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PropTechEntitiesDB context = new PropTechEntitiesDB())
                    {
                        var propiedadExistente = context.Propiedad.Find(id);

                        if (propiedadExistente != null)
                        {
                            propiedadExistente.nombre = propiedad.nombre;
                            propiedadExistente.direccion = propiedad.direccion;
                            propiedadExistente.terreno = propiedad.terreno;
                            propiedadExistente.ciudad = propiedad.ciudad;
                            propiedadExistente.num_cuartos = propiedad.num_cuartos;
                            propiedadExistente.num_baños = propiedad.num_baños;
                            propiedadExistente.num_pisos = propiedad.num_pisos;

                            context.SaveChanges();
                        }
                        else
                        {
                            return HttpNotFound();
                        }
                    }

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                // Manejo de errores
            }

            return View(propiedad);
        }

        // GET: Propiedad/Delete/5
        public ActionResult Delete(int id)
        {
            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                var propiedad = context.Propiedad.Find(id);
                if (propiedad == null)
                {
                    return HttpNotFound();
                }

                context.Propiedad.Remove(propiedad);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
