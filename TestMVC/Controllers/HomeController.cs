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
        public ActionResult Login([Bind(Include = "id_usuario,login,clave")] Usuario usuario)
        {
            if (ModelState.IsValid) {
                //string query = "SELECT * FROM Usuario WHERE login=@p0";
                //var resultado = db.Usuario.SqlQuery(query, usuario).Count();
                /*var obj = db.Usuario.Where(model => model.login.Equals(model.login) && model.clave.Equals(model.clave)).FirstOrDefault();

                if (obj != null) {
                    Session["id_usuario"] = obj.id_usuario.ToString();
                    Session["login"] = obj.login.ToString();
                    return RedirectToAction("Index");
                }*/
                /*using (var cmdr = new SqlCommand("Select id_usuario From Usuario where login=@name and clave=@password and activo=1")) {
                    cmdr.Parameters.AddWithValue("@name", usuario.login);
                    cmdr.Parameters.AddWithValue("@password", usuario.clave);
                    if (cmdr.ExecuteReader().HasRows) {
                        return RedirectToAction("Login");
                    } else {
                        return RedirectToAction("Index");
                    }
                }*/
                string query = "Select * From Usuario where login=@p0 and clave=@p1 and activo=1";
                var num = db.Usuario.SqlQuery(query, usuario.login, usuario.clave).Count();
                if (num>0) {
                    var resultado = db.Usuario.SqlQuery(query, usuario.login, usuario.clave).First();
                    Session["id_usuario"] = resultado.id_usuario;
                    Session["login"] = resultado.login;
                    return RedirectToAction("Index");
                } else {
                    Session.Abandon();
                    return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Login");
        }
    }
}