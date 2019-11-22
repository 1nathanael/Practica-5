using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica5.Models;

namespace Practica5.Controllers
{
    public class AsignaturaController : Controller
    {
        private AsignaturasEntities db = new AsignaturasEntities();
        private Estudiantes estudiante = new Estudiantes();

        // GET: Asignatura
        public ActionResult Index()
        {
            var asignaturaEstudiante = db.AsignaturaEstudiante.Include(a => a.Asignaturas).Include(a => a.Estudiantes);
            return View(estudiante.Listar());
        }

        // GET: Asignatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignaturaEstudiante asignaturaEstudiante = db.AsignaturaEstudiante.Find(id);
            if (asignaturaEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(asignaturaEstudiante);
        }

        // GET: Asignatura/Create
        public ActionResult Create()
        {
            ViewBag.Asignatura_id = new SelectList(db.Asignaturas, "Asignatura_id", "nombre");
            ViewBag.Estudiante_id = new SelectList(db.Estudiantes, "Estudiante_id", "nombre");
            return View();
        }

        // POST: Asignatura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Asignatura_id,Estudiante_id")] AsignaturaEstudiante asignaturaEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.AsignaturaEstudiante.Add(asignaturaEstudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asignatura_id = new SelectList(db.Asignaturas, "Asignatura_id", "nombre", asignaturaEstudiante.Asignatura_id);
            ViewBag.Estudiante_id = new SelectList(db.Estudiantes, "Estudiante_id", "nombre", asignaturaEstudiante.Estudiante_id);
            return View(asignaturaEstudiante);
        }

        // GET: Asignatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignaturaEstudiante asignaturaEstudiante = db.AsignaturaEstudiante.Find(id);
            if (asignaturaEstudiante == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asignatura_id = new SelectList(db.Asignaturas, "Asignatura_id", "nombre", asignaturaEstudiante.Asignatura_id);
            ViewBag.Estudiante_id = new SelectList(db.Estudiantes, "Estudiante_id", "nombre", asignaturaEstudiante.Estudiante_id);
            return View(asignaturaEstudiante);
        }

        // POST: Asignatura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Asignatura_id,Estudiante_id")] AsignaturaEstudiante asignaturaEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignaturaEstudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asignatura_id = new SelectList(db.Asignaturas, "Asignatura_id", "nombre", asignaturaEstudiante.Asignatura_id);
            ViewBag.Estudiante_id = new SelectList(db.Estudiantes, "Estudiante_id", "nombre", asignaturaEstudiante.Estudiante_id);
            return View(asignaturaEstudiante);
        }

        // GET: Asignatura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignaturaEstudiante asignaturaEstudiante = db.AsignaturaEstudiante.Find(id);
            if (asignaturaEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(asignaturaEstudiante);
        }

        // POST: Asignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignaturaEstudiante asignaturaEstudiante = db.AsignaturaEstudiante.Find(id);
            db.AsignaturaEstudiante.Remove(asignaturaEstudiante);
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
