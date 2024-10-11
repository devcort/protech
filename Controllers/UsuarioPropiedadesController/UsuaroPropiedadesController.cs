using Proptech.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Proptech.Controllers
{
    public class UsuarioPropiedadesController : Controller
    {
        private PropTechEntitiesDB db = new PropTechEntitiesDB();

        // GET: UsuarioPropiedades
        public ActionResult Index()
        {
            var usuarioPropiedades = db.Usuario_Propiedades.Include(u => u.Usuario).Include(u => u.Propiedad);
            return View(usuarioPropiedades.ToList());
        }

        // GET: UsuarioPropiedades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_Propiedades usuarioPropiedad = db.Usuario_Propiedades.Find(id);
            if (usuarioPropiedad == null)
            {
                return HttpNotFound();
            }
            return View(usuarioPropiedad);
        }

        // GET: UsuarioPropiedades/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre");
            ViewBag.id_propiedad = new SelectList(db.Propiedad, "id_propiedad", "nombre");
            return View();
        }


        // POST: UsuarioPropiedades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_usuario_propiedad,id_usuario,id_propiedad")] Usuario_Propiedades usuarioPropiedad)
        {
            if (ModelState.IsValid)
            {
                db.Usuario_Propiedades.Add(usuarioPropiedad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", usuarioPropiedad.id_usuario);
            ViewBag.id_propiedad = new SelectList(db.Propiedad, "id_propiedad", "nombre", usuarioPropiedad.id_propiedad);
            return View(usuarioPropiedad);
        }

        // GET: UsuarioPropiedades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_Propiedades usuarioPropiedad = db.Usuario_Propiedades.Find(id);
            if (usuarioPropiedad == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", usuarioPropiedad.id_usuario);
            ViewBag.id_propiedad = new SelectList(db.Propiedad, "id_propiedad", "nombre", usuarioPropiedad.id_propiedad);
            return View(usuarioPropiedad);
        }


        // POST: UsuarioPropiedades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_usuario_propiedad,id_usuario,id_propiedad")] Usuario_Propiedades usuarioPropiedad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioPropiedad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", usuarioPropiedad.id_usuario);
            ViewBag.id_propiedad = new SelectList(db.Propiedad, "id_propiedad", "nombre", usuarioPropiedad.id_propiedad);
            return View(usuarioPropiedad);
        }

        // GET: UsuarioPropiedades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_Propiedades usuarioPropiedad = db.Usuario_Propiedades.Find(id);
            if (usuarioPropiedad == null)
            {
                return HttpNotFound();
            }
            return View(usuarioPropiedad);
        }

        // POST: UsuarioPropiedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario_Propiedades usuarioPropiedad = db.Usuario_Propiedades.Find(id);
            db.Usuario_Propiedades.Remove(usuarioPropiedad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GenerarGrafica()
        {
            var datosGrafica = db.Usuario_Propiedades
                .GroupBy(up => up.Usuario.nombre) // Asegúrate de que 'nombre' es el campo correcto en tu modelo Usuario
                .Select(group => new {
                    Usuario = group.Key,
                    CantidadPropiedades = group.Count()
                })
                .ToList();

            var usuarios = datosGrafica.Select(d => d.Usuario).ToList();
            var cantidades = datosGrafica.Select(d => d.CantidadPropiedades).ToList();

            return Json(new { usuarios = usuarios, propiedades = cantidades }, JsonRequestBehavior.AllowGet);
        }


    }
}
