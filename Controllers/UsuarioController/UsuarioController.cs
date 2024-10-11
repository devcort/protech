using Proptech.Models;
using Proptech.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Usuario = Proptech.Models.DTO.Usuario;

namespace Proptech.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index(string searchString, string sortOrder)
        {
            List<Usuario> listUsuario;

            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                listUsuario = (from u in context.Usuario
                               select new Usuario()
                               {
                                   id_usuario = u.id_usuario,
                                   nombre = u.nombre,
                                   correo = u.correo,
                                   contraseña = u.contraseña,
                               }).ToList();

                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    listUsuario = listUsuario.Where(u =>
                        u.nombre.ToLower().Contains(searchString) ||
                        u.correo.ToLower().Contains(searchString)
                    ).ToList();
                }

                switch (sortOrder)
                {
                    case "nombre_desc":
                        listUsuario = listUsuario.OrderByDescending(u => u.nombre).ToList();
                        break;
                    default:
                        listUsuario = listUsuario.OrderBy(u => u.nombre).ToList();
                        break;
                }
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.NombreSortParm = string.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";

            return View(listUsuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario usuario;
            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                usuario = context.Usuario.Where(u => u.id_usuario == id.Value)
                    .Select(u => new Usuario()
                    {
                        id_usuario = u.id_usuario,
                        nombre = u.nombre,
                        correo = u.correo,
                        contraseña = u.contraseña,
                    }).FirstOrDefault();
            }

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View(new Usuario());
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuarioDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var context = new PropTechEntitiesDB())
                    {
                        var nuevoUsuario = new Proptech.Models.Usuario
                        {
                            nombre = usuarioDto.nombre,
                            correo = usuarioDto.correo,
                            contraseña = usuarioDto.contraseña,
                        };

                        context.Usuario.Add(nuevoUsuario);
                        context.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                // Manejo de errores
            }

            return View(usuarioDto);
        }

        // GET: Contacto/Edit/5
        public ActionResult Edit(int id)
        {
            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                // SQL INSTANCIA
                // Utiliza el método 'FirstOrDefault' directamente en lugar de 'Where' seguido por 'Select'.
                // Esto simplifica la consulta y la hace más legible.
                var usuario = context.Usuario.FirstOrDefault(u => u.id_usuario == id);

                if (usuario == null)
                {
                    return HttpNotFound();
                }

                return View(usuario);
            }
        }


        [HttpPost]
        public ActionResult Edit(int id, Usuario usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioDto);
            }

            try
            {
                using (PropTechEntitiesDB context = new PropTechEntitiesDB())
                {
                    var usuarioExistente = context.Usuario.Find(id);
                    if (usuarioExistente == null)
                    {
                        return HttpNotFound();
                    }

                    // Actualiza las propiedades del usuario existente.
                    usuarioExistente.nombre = usuarioDto.nombre;
                    usuarioExistente.correo = usuarioDto.correo;
                    usuarioExistente.contraseña = usuarioDto.contraseña;

                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Considera registrar el error para un diagnóstico más fácil.
                // Por ejemplo: Log.Error(ex, "Error al editar el usuario");
                ModelState.AddModelError("", "Ocurrió un error al actualizar el usuario.");
                return View(usuarioDto);
            }
        }


        // GET: Contacto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using (PropTechEntitiesDB context = new PropTechEntitiesDB())
            {
                var usuario= context.Usuario.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }

                context.Usuario.Remove(usuario);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
