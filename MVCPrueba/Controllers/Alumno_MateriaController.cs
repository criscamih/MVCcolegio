using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPrueba.Models;

namespace MVCPrueba.Controllers
{
    public class Alumno_MateriaController : Controller
    {
        private CDBContext db = new CDBContext();

        // GET: Alumno_Materia
        public ActionResult Index()
        {
            var alumno_Materia = db.Alumno_Materia.Include(a => a.Alumno).Include(a => a.Materia);
            return View(alumno_Materia.ToList());
        }

        // GET: Alumno_Materia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno_Materia alumno_Materia = db.Alumno_Materia.Find(id);
            if (alumno_Materia == null)
            {
                return HttpNotFound();
            }
            return View(alumno_Materia);
        }

        // GET: Alumno_Materia/Create
        public ActionResult Create()
        {
            ViewBag.Code_Alumno = new SelectList(db.Alumnoes, "Code_Alumno", "Nombres");
            ViewBag.Id_Materia = new SelectList(db.Materias, "Id_materia", "Descripcion");
            return View();
        }

        // POST: Alumno_Materia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_notas,Code_Alumno,Id_Materia,Nota1,Nota2")] Alumno_Materia alumno_Materia)
        {
            if (ModelState.IsValid)
            {
                db.Alumno_Materia.Add(alumno_Materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Code_Alumno = new SelectList(db.Alumnoes, "Code_Alumno", "Nombres", alumno_Materia.Code_Alumno);
            ViewBag.Id_Materia = new SelectList(db.Materias, "Id_materia", "Descripcion", alumno_Materia.Id_Materia);
            return View(alumno_Materia);
        }

        // GET: Alumno_Materia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno_Materia alumno_Materia = db.Alumno_Materia.Find(id);
            if (alumno_Materia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Code_Alumno = new SelectList(db.Alumnoes, "Code_Alumno", "Nombres", alumno_Materia.Code_Alumno);
            ViewBag.Id_Materia = new SelectList(db.Materias, "Id_materia", "Descripcion", alumno_Materia.Id_Materia);
            return View(alumno_Materia);
        }

        // POST: Alumno_Materia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_notas,Code_Alumno,Id_Materia,Nota1,Nota2")] Alumno_Materia alumno_Materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno_Materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Code_Alumno = new SelectList(db.Alumnoes, "Code_Alumno", "Nombres", alumno_Materia.Code_Alumno);
            ViewBag.Id_Materia = new SelectList(db.Materias, "Id_materia", "Descripcion", alumno_Materia.Id_Materia);
            return View(alumno_Materia);
        }

        // GET: Alumno_Materia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno_Materia alumno_Materia = db.Alumno_Materia.Find(id);
            if (alumno_Materia == null)
            {
                return HttpNotFound();
            }
            return View(alumno_Materia);
        }

        // POST: Alumno_Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumno_Materia alumno_Materia = db.Alumno_Materia.Find(id);
            db.Alumno_Materia.Remove(alumno_Materia);
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
