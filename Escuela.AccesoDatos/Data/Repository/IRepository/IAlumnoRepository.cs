using Escuela.Modelos;
namespace Escuela.AccesoDatos.Data.Repository.IRepository
{
    public interface IAlumnoRepository: IRepository<Alumno>
    {
        List<Alumno> Consulta(int idAlumno);
        Alumno Inserta(Alumno entAlumno);
        Alumno Actualiza(Alumno entAlumno);
        Alumno Elimina(int IdAlumno);
    }
}
