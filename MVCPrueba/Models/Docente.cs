using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCPrueba.Models
{
    public class Docente
    {

        public Docente()
        {
            this.Materias = new HashSet<Materia>();
        }
        [Key]
        public int Code_Docente { get; set; }
        public string Nombre_Docente { get; set; }
       

        public virtual ICollection<Materia> Materias { get; set; }

        public void Guardar()
        {
            //var docente = new Docente();

            try
            {
                using (CDBContext db = new CDBContext())
                {
                    if (this.Code_Docente == 0)
                    {
                        db.Entry(this).State = EntityState.Added;
                        foreach (var m in this.Materias)
                        {
                            db.Entry(m).State = EntityState.Unchanged;
                        }
                    }
                    db.SaveChanges();
                }
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public List<Docente> allDocentes()
        {
            var docente = new List<Docente>();

            try
            {
                using (CDBContext db = new CDBContext())
                {
                    docente = db.Docentes.ToList();
                }
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return docente;
        }     
        
        public Docente getConsulta(int id)
        {
            var docente = new Docente();

            try
            {
                using (CDBContext db = new CDBContext())
                {
                    docente = db.Docentes
                           .Include("Materia")
                           .Where(x => x.Code_Docente == id)
                           .Single();
                }
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return docente;
        }
    }
}