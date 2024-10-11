using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proptech.Controllers.PropiedadContactosController
{
    public class PropiedadContactosController : Controller
    {
        // GET: PropiedadContactos
        public ActionResult Index()
        {
            return View();
        }

        // GET: PropiedadContactos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PropiedadContactos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropiedadContactos/Create
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

        // GET: PropiedadContactos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PropiedadContactos/Edit/5
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

        // GET: PropiedadContactos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PropiedadContactos/Delete/5
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
