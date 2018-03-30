using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPrueba.Models
{
    public class Alumno
    {
        
        public Alumno()
        {
            this.Alumnos_Materias = new HashSet<Alumno_Materia>();
        }
        [Key]
        public int Code_Alumno { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Fecha_Nacimiento { get; set; }
        [Required]
        [Remote("VerificarDNI","Alumnoes",ErrorMessage ="Ese Alumno ya existe!")]
        public string DNI { get; set; }
        public virtual ICollection<Alumno_Materia> Alumnos_Materias { get; set; }
    }
}