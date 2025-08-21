using Escuela.Modelos;
namespace Escuela.AccesoDatos.Data.Repository.IRepository
{
    public interface IInscripcionRepository: IRepository<Inscripcion>
    {
        List<Inscripcion> Consulta(int idInscripcion);
        Inscripcion Inserta(Inscripcion entInscripcion);
    }
}
