namespace MVCPrueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno_Materia",
                c => new
                    {
                        Id_notas = c.Int(nullable: false, identity: true),
                        Code_Alumno = c.Int(nullable: false),
                        Id_Materia = c.Int(nullable: false),
                        Nota1 = c.String(),
                        Nota2 = c.String(),
                    })
                .PrimaryKey(t => t.Id_notas)
                .ForeignKey("dbo.Alumnoes", t => t.Code_Alumno, cascadeDelete: true)
                .ForeignKey("dbo.Materias", t => t.Id_Materia, cascadeDelete: true)
                .Index(t => t.Code_Alumno)
                .Index(t => t.Id_Materia);
            
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        Code_Alumno = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Fecha_Nacimiento = c.DateTime(),
                    })
                .PrimaryKey(t => t.Code_Alumno);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        Id_materia = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id_materia);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        Id_curso = c.Int(nullable: false, identity: true),
                        Nivel = c.String(),
                        Id_materias = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_curso)
                .ForeignKey("dbo.Materias", t => t.Id_materias, cascadeDelete: true)
                .Index(t => t.Id_materias);
            
            CreateTable(
                "dbo.Docentes",
                c => new
                    {
                        Code_Docente = c.Int(nullable: false, identity: true),
                        Nombre_Docente = c.String(),
                    })
                .PrimaryKey(t => t.Code_Docente);
            
            CreateTable(
                "dbo.DocenteMaterias",
                c => new
                    {
                        Docente_Code_Docente = c.Int(nullable: false),
                        Materia_Id_materia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Docente_Code_Docente, t.Materia_Id_materia })
                .ForeignKey("dbo.Docentes", t => t.Docente_Code_Docente, cascadeDelete: true)
                .ForeignKey("dbo.Materias", t => t.Materia_Id_materia, cascadeDelete: true)
                .Index(t => t.Docente_Code_Docente)
                .Index(t => t.Materia_Id_materia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumno_Materia", "Id_Materia", "dbo.Materias");
            DropForeignKey("dbo.DocenteMaterias", "Materia_Id_materia", "dbo.Materias");
            DropForeignKey("dbo.DocenteMaterias", "Docente_Code_Docente", "dbo.Docentes");
            DropForeignKey("dbo.Cursoes", "Id_materias", "dbo.Materias");
            DropForeignKey("dbo.Alumno_Materia", "Code_Alumno", "dbo.Alumnoes");
            DropIndex("dbo.DocenteMaterias", new[] { "Materia_Id_materia" });
            DropIndex("dbo.DocenteMaterias", new[] { "Docente_Code_Docente" });
            DropIndex("dbo.Cursoes", new[] { "Id_materias" });
            DropIndex("dbo.Alumno_Materia", new[] { "Id_Materia" });
            DropIndex("dbo.Alumno_Materia", new[] { "Code_Alumno" });
            DropTable("dbo.DocenteMaterias");
            DropTable("dbo.Docentes");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Materias");
            DropTable("dbo.Alumnoes");
            DropTable("dbo.Alumno_Materia");
        }
    }
}
