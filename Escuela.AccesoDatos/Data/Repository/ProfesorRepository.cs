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
    public class ProfesorRepository: Repository<Profesor>, IProfesorRepository
    {
        private readonly ApplicationDbContext _db; //contexto de la base de datos
        private readonly IConfiguration _configuration; //configuracion de la aplicacion
        private readonly string cadenaSQL = string.Empty;
        public ProfesorRepository(ApplicationDbContext db, IConfiguration configuration) : base(db, configuration) //llama al constructor de la clase base
        {
            _configuration = configuration; //inicializa la configuracion de la aplicacion
            cadenaSQL = configuration.GetConnectionString("ConexionSQL");
            _db = db; //inicializa el contexto de la base de datos
        }
        public List<Profesor> Consulta(int idProfesor)
        {
            List<Profesor> lstProfesor = new List<Profesor>();
            Profesor profesor = new Profesor();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpProfesorConsulta", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdProfesor", idProfesor);
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            profesor = new Profesor();
                            profesor.IdProfesor = Convert.ToInt32(rd["IdProfesor"]);
                            profesor.Nombre = rd["Nombre"].ToString();
                            profesor.Apellido = rd["Apellido"].ToString();
                            profesor.DNI = rd["DNI"].ToString();
                            lstProfesor.Add(profesor);
                        }
                    }
                }
                return lstProfesor;
            }
            catch (Exception error)
            {
                return lstProfesor;
            }
        }

        public Profesor Inserta(Profesor entProfesor)
        {
            Profesor profesor = new Profesor();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpProfesorInserta", conexion);                    
                    cmd.Parameters.AddWithValue("Nombre", entProfesor.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", entProfesor.Apellido);
                    cmd.Parameters.AddWithValue("DNI", entProfesor.DNI);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            profesor.IdProfesor = Convert.ToInt32(rd["IdRegistro"]);
                            profesor.mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return profesor;
            }
            catch (Exception error)
            {
                return profesor;
            }
        }

        public Profesor Actualiza(Profesor entidad)
        {
            Profesor profesor = new Profesor();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpProfesorActualiza", conexion);
                    cmd.Parameters.AddWithValue("IdProfesor", entidad.IdProfesor);
                    cmd.Parameters.AddWithValue("Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", entidad.Apellido);
                    cmd.Parameters.AddWithValue("DNI", entidad.DNI);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            profesor.IdProfesor = Convert.ToInt32(rd["IdRegistro"]);
                            profesor.mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return profesor;
            }
            catch (Exception error)
            {
                return profesor;
            }
        }

        public Profesor Elimina(int idProfesor)
        {
            Profesor profesor = new Profesor();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpProfesorElimina", conexion);
                    cmd.Parameters.AddWithValue("IdProfesor", idProfesor);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            profesor.IdProfesor = Convert.ToInt32(rd["IdRegistro"]);
                            profesor.mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return profesor;
            }
            catch (Exception error)
            {
                return profesor;
            }
        }


    }
}
