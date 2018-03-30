using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPrueba.Models
{
    public class DocenteMateriaDetalle
    {
        public ICollection<Docente> docentes { get; set; }
        public ICollection<Materia> materias { get; set; }
    }
}