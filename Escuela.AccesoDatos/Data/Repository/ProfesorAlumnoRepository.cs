using Escuela.AccesoDatos.Data.Repository.IRepository;
using Escuela.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace Escuela.AccesoDatos.Data.Repository
{
    public class ProfesorAlumnoRepository : Repository<ProfesorAlumno>, IProfesorAlumnoRepository
    {
        private readonly ApplicationDbContext _db; //contexto de la base de datos
        private readonly IConfiguration _configuration; //configuracion de la aplicacion
        private readonly string cadenaSQL = string.Empty;
        public ProfesorAlumnoRepository(ApplicationDbContext db, IConfiguration configuration) : base(db, configuration) //llama al constructor de la clase base
        {
            _configuration = configuration; //inicializa la configuracion de la aplicacion
            cadenaSQL = configuration.GetConnectionString("ConexionSQL");
            _db = db; //inicializa el contexto de la base de datos
        }
        public List<ProfesorAlumno> Consulta(int idProfesor)
        {
            List<ProfesorAlumno> lstProfesorAlumno = new List<ProfesorAlumno>();
            ProfesorAlumno profesorAlumno = new ProfesorAlumno();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpProfesorAlumnosConsulta", conexion);
                    cmd.Parameters.AddWithValue("IdProfesor", idProfesor);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            profesorAlumno = new ProfesorAlumno();
                            profesorAlumno.LstProfesor.Nombre = rd["Profesor"].ToString();
                            profesorAlumno.LstInscripcion.LstEscuela.Nombre = rd["Escuela"].ToString();
                            profesorAlumno.LstInscripcion.LstAlumno.Nombre = rd["Alumno"].ToString();
                            lstProfesorAlumno.Add(profesorAlumno);
                        }
                    }
                }
                return lstProfesorAlumno;
            }
            catch (Exception error)
            {
                return lstProfesorAlumno;
            }
        }

        public ProfesorAlumno Inserta(ProfesorAlumno entProfesorAlumno)
        {
            ProfesorAlumno profesorAlumno = new ProfesorAlumno();
            if (entProfesorAlumno == null)
            {
                return profesorAlumno;
            }
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpProfesorAlumnoInserta", conexion);
                    cmd.Parameters.AddWithValue("IdProfesor", entProfesorAlumno.IdProfesor);
                    cmd.Parameters.AddWithValue("IdInscripcion", entProfesorAlumno.IdInscripcion);
                    cmd.Parameters.AddWithValue("IdEscuela", entProfesorAlumno.LstInscripcion.LstEscuela.IdEscuela);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            profesorAlumno.IdProfAlum = Convert.ToInt32(rd["IdRegistro"]);
                            profesorAlumno.Mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return profesorAlumno;
            }
            catch (Exception error)
            {
                return profesorAlumno;
            }
        }
    }
}
