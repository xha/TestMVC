using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using System.Data.SqlClient;

namespace TestMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private TestMVCContext db = new TestMVCContext();

        // GET: Usuario
        public ActionResult Index()
        {
            if (Session["id_usuario"] != null) {
                //string query = "SELECT * FROM Persona WHERE activo=1 ORDER BY nombre";
                //ViewBag.ListItem = db.Persona.SqlQuery(query).ToList();
                //return View(db.Usuario.ToList());
                //var union = db.Usuario.Join(db.Persona, u => u.id_persona, p => p.id_persona, (u, p) => new { u, p }).Where(x => x.p.activo == true).ToList();
                IEnumerable<Usuario> q = (from p in db.Persona
                                          join u in db.Usuario on p.id_persona equals u.id_persona
                                          select new
                                          {
                                              id_usuario = u.id_usuario,
                                              id_persona = u.id_persona,
                                              nombre = p.nombre,
                                              login = u.login,
                                              fecha_registro = u.fecha_registro,
                                              activo = u.activo,
                                          }).ToList()
                           .Select(x => new Usuario
                           {
                               id_usuario = x.id_usuario,
                               id_persona = x.id_persona,
                               clave = x.nombre,
                               login = x.login,
                               fecha_registro = x.fecha_registro,
                               activo = x.activo,
                           });
            return View(q);
            } else {
                return RedirectToAction("../Home/Login");
            }
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            string query = "SELECT * FROM Persona WHERE activo=1 ORDER BY nombre";
            ViewBag.ListItem = db.Persona.SqlQuery(query).ToList();
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_usuario,id_persona,fecha_registro,login,clave,activo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.fecha_registro = DateTime.Now;
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            string query = "SELECT * FROM Persona WHERE activo=1 ORDER BY nombre";
            ViewBag.ListItem = db.Persona.SqlQuery(query).ToList();
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_usuario,id_persona,fecha_registro,login,clave,activo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult BuscarUsuario(string usuario)
        {
            string query = "SELECT * FROM Usuario WHERE login=@p0";
            var resultado = db.Usuario.SqlQuery(query, usuario).Count();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async System.Threading.Tasks.Task<JsonResult> BuscarPersona(int id)
        {
            string query = "SELECT * FROM Persona WHERE id_persona=@p0";
            Persona persona = await db.Persona.SqlQuery(query, id).FirstOrDefaultAsync();
            
            return Json(persona, JsonRequestBehavior.AllowGet);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*Usuario usuario = db.Usuario.Find(id);
            usuario.activo = false;
            db.SaveChanges();
            return RedirectToAction("Index");*/
            //SqlCommand cmd = new SqlCommand("UPDATE Usuario SET activo=0 WHERE login=@p0");
            //cmd.ExecuteNonQuery();
            //string query = "UPDATE Usuario SET activo=0 WHERE id_usuario=@p0";
            //db.Usuario.SqlQuery(query, id).FirstOrDefaultAsync();
            Usuario usuario = db.Usuario.Find(id);
            usuario.activo = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
