using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCPrueba.Models
{
    public class Alumno_Materia
    {
        [Key]
        public int Id_notas { get; set; }
        [ForeignKey("Alumno")]
        public int Code_Alumno { get; set; }
        [ForeignKey("Materia")]
        public int Id_Materia { get; set; }
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Máximo dos números decimales")]
        
        public string Nota1 { get; set; }
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Máximo dos números decimales")]
       
        public string Nota2 { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Materia Materia { get; set; }
    }
}