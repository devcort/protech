using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proptech.Controllers.AmenidadPropiedadController
{
    public class AmenidadPropiedadController : Controller
    {
        // GET: AmenidadPropiedad
        public ActionResult Index()
        {
            return View();
        }

        // GET: AmenidadPropiedad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AmenidadPropiedad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AmenidadPropiedad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AmenidadPropiedad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AmenidadPropiedad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AmenidadPropiedad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AmenidadPropiedad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
