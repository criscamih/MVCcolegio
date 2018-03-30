CREATE PROCEDURE [dbo].[sp_Reporte_de_Notas]
AS
SELECT Nombres,Apellidos, Descripcion as [Asignatura],Nota1,Nota2,Nombre_Docente as [Docente] from Alumnoes join
Alumno_Materia on Alumnoes.Code_Alumno=Alumno_Materia.Code_Alumno join
Materias on Alumno_Materia.Id_Materia=Materias.Id_materia join
DocenteMaterias on Materias.Id_materia=DocenteMaterias.Materia_Id_materia join
Docentes on DocenteMaterias.Docente_Code_Docente=Docentes.Code_Docente
GO
