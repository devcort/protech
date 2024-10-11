using Proptech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ciudad = Proptech.Models.DTO.Ciudad;

namespace Proptech.Controllers.CiudadController
{
    public class CiudadController : Controller
    {
        // GET: Ciudad
        public ActionResult Index()
        {
            List<Ciudad> listCiudad;

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                listCiudad = context.Ciudad.Select(c => new Ciudad
                {
                    id_ciudad = c.id_ciudad,
                    nombre_ciudad = c.nombre_ciudad,
                }).ToList();
            }

            return View(listCiudad);
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(int id)
        {
            Ciudad ciudad;

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                ciudad = context.Ciudad
                    .Where(c => c.id_ciudad == id)
                    .Select(c => new Ciudad
                    {
                        id_ciudad = c.id_ciudad,
                        nombre_ciudad = c.nombre_ciudad,
                    }).FirstOrDefault();
            }

            if (ciudad == null)
            {
                return HttpNotFound();
            }

            return View(ciudad);
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            return View(new Ciudad());
        }

        // POST: Ciudad/Create
        [HttpPost]
        public ActionResult Create(Ciudad ciudadDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var context = new PropTechEntitiesDB())
                    {
                        var nuevaCiudad = new Proptech.Models.Ciudad
                        {
                            nombre_ciudad = ciudadDto.nombre_ciudad,
                            
                        };

                        context.Ciudad.Add(nuevaCiudad);
                        context.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                // Manejo de errores
            }

            return View(ciudadDto);
        }

        // GET: Ciudad/Edit/5
        public ActionResult Edit(int id)
        {
            Ciudad ciudad;

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                ciudad = context.Ciudad
                    .Where(c => c.id_ciudad == id)
                    .Select(c => new Ciudad
                    {
                        id_ciudad = c.id_ciudad,
                        nombre_ciudad = c.nombre_ciudad,
                    }).FirstOrDefault();
            }

            if (ciudad == null)
            {
                return HttpNotFound();
            }

            return View(ciudad);
        }

        // POST: Ciudad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Ciudad ciudadDto)
        {
            try
            {
                using (PropTechEntitiesDB context = new PropTechEntitiesDB())
                {
                    var ciudadExistente = context.Ciudad.Find(id);

                    if (ciudadExistente != null)
                    {
                        ciudadExistente.nombre_ciudad = ciudadDto.nombre_ciudad;

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
                return View(ciudadDto);
            }
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(int id)
        {
            Ciudad ciudad;

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                ciudad = context.Ciudad
                    .Where(c => c.id_ciudad == id)
                    .Select(c => new Ciudad
                    {
                        id_ciudad = c.id_ciudad,
                        nombre_ciudad = c.nombre_ciudad,
                    }).FirstOrDefault();
            }

            if (ciudad == null)
            {
                return HttpNotFound();
            }

            return View(ciudad);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                var ciudad = context.Ciudad.Find(id);

                if (ciudad != null)
                {
                    context.Ciudad.Remove(ciudad);
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
}
