using Proptech.Models;
using Proptech.Models.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contactos = Proptech.Models.DTO.Contactos;

namespace Proptech.Controllers.ContactoController
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Index(string searchString, string sortOrder)
        {
            List<Contactos> listContacto;

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                listContacto = (from c in context.Contactos
                                select new Contactos()
                                {
                                    id_contactos = c.id_contactos,
                                    nombre = c.nombre,
                                    telefono = c.telefono,
                                    email = c.email,
                                    clasificacion = c.clasificacion,
                                    direccion = c.direccion,
                                }).ToList();

                // Aplicar filtros de búsqueda si se proporciona un término de búsqueda
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower(); // Convertir a minúsculas para una búsqueda sin distinción entre mayúsculas y minúsculas
                    listContacto = listContacto.Where(c =>
                        c.nombre.ToLower().Contains(searchString) ||
                        c.telefono.ToLower().Contains(searchString) ||
                        c.email.ToLower().Contains(searchString) ||
                        c.clasificacion.ToLower().Contains(searchString) ||
                        c.direccion.ToLower().Contains(searchString)
                    ).ToList();
                }

                // Aplicar ordenamiento
                switch (sortOrder)
                {
                    case "nombre_desc":
                        listContacto = listContacto.OrderByDescending(c => c.nombre).ToList();
                        break;
                    default:
                        listContacto = listContacto.OrderBy(c => c.nombre).ToList();
                        break;
                }
            }

            ViewBag.CurrentFilter = searchString; // Mantener el valor de búsqueda en la vista
            ViewBag.NombreSortParm = string.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";

            return View(listContacto);
        }



        // GET: Contacto/Details/5
        public ActionResult Details(int? id)
        {
            Contactos contacto;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                contacto = (from c in context.Contactos
                            where c.id_contactos == id
                            select new Contactos()
                            {
                                id_contactos = c.id_contactos,
                                nombre = c.nombre,
                                telefono = c.telefono,
                                email = c.email,
                                clasificacion = c.clasificacion,
                                direccion = c.direccion
                            }).FirstOrDefault();
            }

            if (contacto == null)
            {
                return HttpNotFound();
            }

            return View(contacto);


        }
        // GET: Contacto/Create
        public ActionResult Create()
        {
            return View(new Contactos()); // Usa el DTO aquí
        }

        // POST: Contacto/Create
        [HttpPost]
        public ActionResult Create(Contactos contactoDto) // Usa el DTO como parámetro
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var context = new PropTechEntitiesDB())
                    {
                        var nuevoContacto = new Proptech.Models.Contactos
                        {
                            // No asignamos un valor al campo id_contactos
                            // La base de datos se encargará de generar el valor automáticamente
                            nombre = contactoDto.nombre,
                            telefono = contactoDto.telefono,
                            email = contactoDto.email,
                            clasificacion = contactoDto.clasificacion,
                            direccion = contactoDto.direccion
                        };

                        context.Contactos.Add(nuevoContacto); // Agrega el nuevo contacto a la base de datos
                        context.SaveChanges(); // Guarda los cambios
                    }

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                // Manejo de errores
            }

            return View(contactoDto); // Vuelve a mostrar la vista de creación con el DTO
        }

        // GET: Contacto/Edit/5
        public ActionResult Edit(int id)
        {

            Contactos contacto;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                contacto = (from c in context.Contactos
                            where c.id_contactos == id
                            select new Contactos()
                            {
                                id_contactos = c.id_contactos,
                                nombre = c.nombre,
                                telefono = c.telefono,
                                email = c.email,
                                clasificacion = c.clasificacion,
                                direccion = c.direccion
                            }).FirstOrDefault();
            }

            if (contacto == null)
            {
                return HttpNotFound();
            }

            return View(contacto);
        }

        // POST: Contacto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                using (PropTechEntitiesDB context = new PropTechEntitiesDB())
                {
                    // Buscar el contacto por su ID en la base de datos
                    var contactoExistente = context.Contactos.Find(id);

                    if (contactoExistente != null)
                    {
                        // Actualizar los campos del modelo con los valores del formulario
                        contactoExistente.nombre = collection["nombre"];
                        contactoExistente.telefono = collection["telefono"];
                        contactoExistente.email = collection["email"];
                        contactoExistente.clasificacion = collection["clasificacion"];
                        contactoExistente.direccion = collection["direccion"];

                        // Guardar los cambios en la base de datos
                        context.SaveChanges();
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                var contacto = context.Contactos.Find(id);
                if (contacto == null)
                {
                    return HttpNotFound();
                }

                context.Contactos.Remove(contacto);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
