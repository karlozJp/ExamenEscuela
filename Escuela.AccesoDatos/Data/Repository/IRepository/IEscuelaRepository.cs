
namespace Escuela.AccesoDatos.Data.Repository.IRepository
{
    public interface IEscuelaRepository: IRepository<Modelos.Escuela>
    {
        List<Modelos.Escuela> Consulta(int idEscuela);
        Modelos.Escuela Inserta(Modelos.Escuela entEscuela);
        Modelos.Escuela Actualiza(Modelos.Escuela entEscuela);
        Modelos.Escuela Elimina(int IdEscuela);

    }
}
