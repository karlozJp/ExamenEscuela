using Escuela.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela.AccesoDatos.Data.Repository.IRepository
{
    public interface IEscuelaProfesor: IRepository<EscuelaProfesor>
    {
        List<EscuelaProfesor> Consulta();
        EscuelaProfesor Inserta(EscuelaProfesor entEscProf);
    }
}
