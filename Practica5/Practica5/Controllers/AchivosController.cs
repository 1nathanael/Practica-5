using Practica5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica5.Controllers
{
    public class AchivosController : Controller
    {
        // GET: Achivos
        public ActionResult Index()
        {
            return View(new List<Modificador>);
        }

        [HttpPost]
        public ActionResult index(HttpPostedFileBase postedFile)
        {
            List<Modificador> M = new List<Modificador>();
            string archivo = string.Empty;

            if(postedFile != null)
            {
                string ruta = Server.MapPath("~/Archivos/");
            }
        }
    }
}