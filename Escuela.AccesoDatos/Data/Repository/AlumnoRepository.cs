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
    public class AlumnoRepository : Repository<Alumno>, IAlumnoRepository
    {
        private readonly ApplicationDbContext _db; //contexto de la base de datos
        private readonly IConfiguration _configuration; //configuracion de la aplicacion
        private readonly string cadenaSQL = string.Empty;

        public AlumnoRepository(ApplicationDbContext db, IConfiguration configuration) : base(db, configuration) //llama al constructor de la clase base
        {
            _configuration = configuration; //inicializa la configuracion de la aplicacion
            cadenaSQL = configuration.GetConnectionString("ConexionSQL");
            _db = db; //inicializa el contexto de la base de datos
        }

        public List<Alumno> Consulta(int idAlumno)
        {
            List<Alumno> lstAlumno = new List<Alumno>();
            Alumno alumno = new Alumno();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpAlumnoConsulta", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdAlumno", idAlumno);
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            alumno = new Alumno();
                            alumno.IdAlumno = Convert.ToInt32(rd["IdAlumno"]);
                            alumno.Nombre = rd["Nombre"].ToString();
                            alumno.Apellido = rd["Apellido"].ToString();
                            alumno.FechaNacimiento = rd["FechaNacimiento"].ToString();
                            alumno.matricula = rd["Matricula"].ToString();
                            lstAlumno.Add(alumno);
                        }
                    }
                }
                return lstAlumno;
            }
            catch (Exception error)
            {
                return lstAlumno;
            }
        }

        public Alumno Inserta(Alumno entAlumno)
        {
            Alumno alumno = new Alumno();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpAlumnoInserta", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre", entAlumno.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", entAlumno.Apellido);
                    cmd.Parameters.AddWithValue("FechaNacimiento", entAlumno.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Matricula", entAlumno.matricula);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            alumno.IdAlumno = Convert.ToInt32(rd["IdRegistro"]);
                            alumno.Mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return alumno;
            }
            catch (Exception error)
            {
                return alumno;
            }
        }

        public Alumno Actualiza(Alumno entAlumno)
        {
            Alumno alumno = new Alumno();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpAlumnoActualiza", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdAlumno", entAlumno.IdAlumno);
                    cmd.Parameters.AddWithValue("Nombre", entAlumno.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", entAlumno.Apellido);
                    cmd.Parameters.AddWithValue("FechaNacimiento", entAlumno.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Matricula", entAlumno.matricula);
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            alumno.IdAlumno = Convert.ToInt32(rd["IdRegistro"]);
                            alumno.Mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return alumno;
            }
            catch (Exception error)
            {
                return alumno;
            }
        }

        public Alumno Elimina(int idAlumno)
        {
            Alumno alumno = new Alumno();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpAlumnoElimina", conexion);
                    cmd.Parameters.AddWithValue("IdAlumno", idAlumno);
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            alumno.IdAlumno = Convert.ToInt32(rd["IdRegistro"]);
                            alumno.Mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return alumno;
            }
            catch (Exception error)
            {
                return alumno;
            }
        }
    }
}
