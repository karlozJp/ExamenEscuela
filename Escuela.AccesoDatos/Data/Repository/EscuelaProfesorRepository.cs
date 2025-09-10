using Escuela.AccesoDatos.Data.Repository.IRepository;
using Escuela.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela.AccesoDatos.Data.Repository
{
    public class EscuelaProfesorRepository : Repository<EscuelaProfesor>, IEscuelaProfesor
    {
        private readonly ApplicationDbContext _db; //contexto de la base de datos
        private readonly IConfiguration _configuration; //configuracion de la aplicacion
        private readonly string cadenaSQL = string.Empty;
        public EscuelaProfesorRepository(ApplicationDbContext db, IConfiguration configuration) : base(db, configuration) //llama al constructor de la clase base
        {
            _configuration = configuration; //inicializa la configuracion de la aplicacion
            cadenaSQL = configuration.GetConnectionString("ConexionSQL");
            _db = db; //inicializa el contexto de la base de datos
        }
        public List<EscuelaProfesor> Consulta()
        {
            List<EscuelaProfesor> lstEscProf = new List<EscuelaProfesor>();
            EscuelaProfesor ent = new EscuelaProfesor();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpEscuelasProfesorConsulta", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            ent.LstEscuela.Nombre = rd["Escuela"].ToString();
                            ent.LstProfesor.Nombre = rd["Profesor"].ToString();
                            ent.LstAlumno.Nombre = rd["Alumno"].ToString();
                            lstEscProf.Add(ent);
                        }
                    }
                }

                return lstEscProf;
            }
            catch (Exception error)
            {
                return lstEscProf;
            }
        }

        public EscuelaProfesor Inserta(EscuelaProfesor entEscProf)
        {
            EscuelaProfesor ent = new EscuelaProfesor();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpEscuelaProfesorInserta", conexion);
                    cmd.Parameters.AddWithValue("IdEscuela", entEscProf.IdEscuela);
                    cmd.Parameters.AddWithValue("IdProfesor", entEscProf.IdProfesor);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            ent.IdEscuelaProf = Convert.ToInt32(rd["IdRegistro"]);
                            ent.Mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return ent;
            }
            catch (Exception error)
            {
                return ent;
            }
        }
    }
}
