using Practica5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica5.Controllers
{
    public class ArchivosController : Controller
    {
        public object JOptionpane { get; private set; }
        public object MessageBox { get; private set; }

        // GET: Achivos
        public ActionResult Index()
        {
            return View(new List<Modificador>());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            List<Modificador> M = new List<Modificador>();
            string archivo = string.Empty;

            if(postedFile != null)
            {
                string ruta = Server.MapPath("~/Archivos/");
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                archivo = ruta + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(archivo);

                string Dexel = System.IO.File.ReadAllText(archivo);
                foreach (string row in Dexel.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        M.Add(new Modificador
                        {
                            ID = Convert.ToInt32(row.Split(',')[0]),
                            Nombre = row.Split(',')[1],
                            Descripcion = row.Split(',')[2]
                        });
                    }
                    
                }
            }

            return View(M);
        }
    }
}