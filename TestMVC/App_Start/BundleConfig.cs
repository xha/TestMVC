﻿using System.Web;
using System.Web.Optimization;

namespace TestMVC
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/general.css",
                      "~/Content/site.css"));
            /************************************************************************************************/
            //AGREGADOS HL 06/05/2018
            bundles.Add(new ScriptBundle("~/bundles/usuario").Include(
                        "~/Scripts/usuario.js"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                        "~/Scripts/login.js"));

            bundles.Add(new ScriptBundle("~/bundles/producto").Include(
                        "~/Scripts/producto.js"));

            bundles.Add(new ScriptBundle("~/bundles/persona").Include(
                        "~/Scripts/persona.js"));
            /************************************************************************************************/
        }
    }
}
