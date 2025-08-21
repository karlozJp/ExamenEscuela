using Escuela.AccesoDatos.Data.Repository.IRepository;
using Escuela.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Escuela.AccesoDatos.Data.Repository
{
    public class InscripcionRepository : Repository<Inscripcion>, IInscripcionRepository
    {
        private readonly ApplicationDbContext _db; //contexto de la base de datos
        private readonly IConfiguration _configuration; //configuracion de la aplicacion
        private readonly string cadenaSQL = string.Empty;
        public InscripcionRepository(ApplicationDbContext db, IConfiguration configuration) : base(db, configuration) //llama al constructor de la clase base
        {
            _configuration = configuration; //inicializa la configuracion de la aplicacion
            cadenaSQL = configuration.GetConnectionString("ConexionSQL");
            _db = db; //inicializa el contexto de la base de datos
        }
        public List<Inscripcion> Consulta(int idInscripcion)
        {
            List<Inscripcion> lstInscripcion = new List<Inscripcion>();
            Inscripcion inscripcion = new Inscripcion();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpInscripcionConsulta", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdInscripcion", idInscripcion);
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            inscripcion = new Inscripcion();
                            inscripcion.IdInscripcion = Convert.ToInt32(rd["IdInscripcion"]);
                            inscripcion.LstEscuela.Nombre = rd["Escuela"].ToString();
                            inscripcion.LstAlumno.Nombre = rd["Alumno"].ToString();
                            lstInscripcion.Add(inscripcion);
                        }
                    }
                }
                return lstInscripcion;
            }
            catch (Exception error)
            {
                return lstInscripcion;
            }
        }
        public Inscripcion Inserta(Inscripcion entInscripcion)
        {
            Inscripcion inscripcion = new Inscripcion();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpInscripcionInserta", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdEscuela", entInscripcion.IdEscuela);
                    cmd.Parameters.AddWithValue("IdAlumno", entInscripcion.IdAlumno);
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            inscripcion.IdInscripcion = Convert.ToInt32(rd["IdRegistro"]);
                            inscripcion.Mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return inscripcion;
            }
            catch (Exception error)
            {
                return inscripcion;
            }
        }
    }
}
