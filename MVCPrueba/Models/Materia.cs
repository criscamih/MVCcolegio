using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPrueba.Models
{
    public class Materia
    {
        public Materia()
        {
            
            this.Alumnos_Materias = new HashSet<Alumno_Materia>();
            this.Docentes = new HashSet<Docente>();
        }
        [Key]
        public int Id_materia { get; set; }

        public string Descripcion { get; set; }

        
       
        
        public virtual ICollection<Alumno_Materia> Alumnos_Materias { get; set; }
        
        public virtual ICollection<Docente> Docentes { get; set; }

        public List<Materia> allMaterias()
        {
            var materias = new List<Materia>();

            try
            {
                using (CDBContext db = new CDBContext())
                {
                    materias = db.Materias.ToList();
                }
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return materias;
        }
    }
}