using Escuela.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela.AccesoDatos.Data.Repository.IRepository
{
    public interface IProfesorRepository : IRepository<Profesor>
    {
        List<Profesor> Consulta(int idProfesor);
        Profesor Inserta(Profesor entProfesor);
        Profesor Actualiza(Profesor entProfesor);
        Profesor Elimina(int IdProfesor);
    }
}
