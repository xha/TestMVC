using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using System.Data.SqlClient;

namespace TestMVC.Controllers
{
    public class HomeController : Controller
    {
        private TestMVCContext db = new TestMVCContext();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "login,clave")] Usuario usuario)
        {
            if (ModelState.IsValid) {
                string query = "Select * From Usuario where login=@p0 and clave=@p1 and activo=1";
                var num = db.Usuario.SqlQuery(query, usuario.login, usuario.clave).Count();
                if (num>0) {
                    var resultado = db.Usuario.SqlQuery(query, usuario.login, usuario.clave).First();
                    Session["id_usuario"] = resultado.id_usuario;
                    Session["login"] = resultado.login;
                    return RedirectToAction("Index");
                } else {
                    Session.Abandon();
                    ViewBag.Message = "Error en el Login";
                    return View();
                }
            }
            return RedirectToAction("Login");
        }
    }
}