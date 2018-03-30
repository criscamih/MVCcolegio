using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class CDBContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public CDBContext() : base("name=CDBContext")
    {
    }

    

    public System.Data.Entity.DbSet<MVCPrueba.Models.Materia> Materias { get; set; }

    public System.Data.Entity.DbSet<MVCPrueba.Models.Curso> Cursoes { get; set; }

    public System.Data.Entity.DbSet<MVCPrueba.Models.Docente> Docentes { get; set; }

    public System.Data.Entity.DbSet<MVCPrueba.Models.Alumno_Materia> Alumno_Materia { get; set; }

    public System.Data.Entity.DbSet<MVCPrueba.Models.Alumno> Alumnoes { get; set; }
}
