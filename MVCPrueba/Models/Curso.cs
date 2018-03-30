using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCPrueba.Models
{
    public class Curso
    {
        [Key]
        public int Id_curso { get; set; }
        public string Nivel { get; set; }
        [ForeignKey("Materia")]
        public int Id_materias { get; set; }

        public virtual Materia Materia { get; set; }
    }
}