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
    public class DocentesController : Controller
    {
        private CDBContext db = new CDBContext();
        private Docente docente = new Docente();
        private Materia materia = new Materia();
        
        // GET: Docentes
        public ActionResult Index()
        {
            var doc = db.Docentes.ToList();
            return View(doc);
        }
        
        public ActionResult Guardar(Docente profe,int[]materias=null)
        {
            if (materia != null)
            {
                foreach (var materia in materias)
                {
                    profe.Materias.Add(new Materia { Id_materia = materia });
                }
            }
            profe.Guardar();
            return RedirectToAction("Index");
        }
        public ActionResult Reporte()
        {
            var notas = db.Database.SqlQuery<ReporteNotas>("sp_Reporte_de_Notas").ToList();
            return View(notas);
        }
        // GET: Docentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // GET: Docentes/Create
        public ActionResult Create(int id=0)
        {
            var lista = db.Materias.ToList();
            lista.Add(new Materia { Id_materia = 0, Descripcion = "[Materia]" });
            lista = lista.OrderBy(c => c.Descripcion).ToList();
            ViewBag.Asignatura = new SelectList(lista, "Id_materia", "Descripcion");
            var ma= new SelectList(lista, "Id_materia", "Descripcion");

            ma.Select(x => x.Value).ToList();
            ViewBag.Materias = materia.allMaterias();
            return View(id > 0 ? docente.getConsulta(id) : docente);
        }

        // POST: Docentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code_Docente,Nombre_Docente")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Docentes.Add(docente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docente);
        }

        // GET: Docentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code_Docente,Nombre_Docente")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docente);
        }

        // GET: Docentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Docente docente = db.Docentes.Find(id);
            db.Docentes.Remove(docente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DoceteMateria(int id = 0)
        {
            var lista = db.Docentes.ToList();
            lista.Add(new Docente { Code_Docente = 0, Nombre_Docente = "[Docente]" });
            lista = lista.OrderBy(c => c.Nombre_Docente).ToList();
            ViewBag.docentes = new SelectList(lista, "Code_Docente", "Nombre_Docente");
            var ma = new SelectList(lista, "Code_Docente", "Nombre_Docente");
       
            ma.Select(x => x.Value).ToList();
            ViewBag.Materias = materia.allMaterias();
            return View(id > 0 ? docente.getConsulta(id) : docente); 
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
