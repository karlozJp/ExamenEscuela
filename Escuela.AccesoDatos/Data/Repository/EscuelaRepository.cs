using Escuela.AccesoDatos.Data.Repository.IRepository;
using Escuela.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Escuela.AccesoDatos.Data.Repository
{
    public class EscuelaRepository : Repository<Modelos.Escuela>, IEscuelaRepository
    {
        private readonly ApplicationDbContext _db; //contexto de la base de datos
        private readonly IConfiguration _configuration; //configuracion de la aplicacion
        private readonly string cadenaSQL = string.Empty;
        public EscuelaRepository(ApplicationDbContext db, IConfiguration configuration) : base(db, configuration) //llama al constructor de la clase base
        {
            _configuration = configuration; //inicializa la configuracion de la aplicacion
            cadenaSQL = configuration.GetConnectionString("ConexionSQL");
            _db = db; //inicializa el contexto de la base de datos
        }

        public List<Modelos.Escuela> Consulta(int idEscuela)
        {
            List<Modelos.Escuela> lstEscuela = new List<Modelos.Escuela>();
            Modelos.Escuela escuela = new Modelos.Escuela();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) //crea una instancia del contexto de la base de datos
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpEscuelaConsulta", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdEscuela", idEscuela);
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            escuela = new Modelos.Escuela();
                            escuela.IdEscuela = Convert.ToInt32(rd["IdEscuela"]);
                            escuela.Nombre = rd["Nombre"].ToString();
                            escuela.Descripcion = rd["Descripcion"].ToString();
                            escuela.Codigo = rd["Codigo"].ToString();
                            lstEscuela.Add(escuela);
                        }
                    }
                }
                return lstEscuela;
            }
            catch (Exception error)
            {
                return lstEscuela;
            }
        }
        public Modelos.Escuela Inserta(Modelos.Escuela entEscuela)
        {
            Modelos.Escuela escuela = new Modelos.Escuela();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SPEscuelaInserta", conexion);
                    cmd.Parameters.AddWithValue("Nombre", entEscuela.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", entEscuela.Descripcion);
                    cmd.Parameters.AddWithValue("Codigo", entEscuela.Codigo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            escuela.IdEscuela = Convert.ToInt32(rd["IdRegistro"]);
                            escuela.Mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return escuela;
            }
            catch (Exception error)
            {
                return escuela;
            }
        }
        public Modelos.Escuela Actualiza(Modelos.Escuela entEscuela)
        {
            Modelos.Escuela escuela = new Modelos.Escuela();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpEscuelaActualiza", conexion);
                    cmd.Parameters.AddWithValue("IdEscuela", entEscuela.IdEscuela);
                    cmd.Parameters.AddWithValue("Nombre", entEscuela.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", entEscuela.Descripcion);
                    cmd.Parameters.AddWithValue("Codigo", entEscuela.Codigo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            escuela.IdEscuela = Convert.ToInt32(rd["IdRegistro"]);
                            escuela.Mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return escuela;
            }
            catch (Exception error)
            {
                return escuela;
            }
        }
        public Modelos.Escuela Elimina(int IdEscuela)
        {
            Modelos.Escuela escuela = new Modelos.Escuela();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SpEscuelaElimina", conexion);
                    cmd.Parameters.AddWithValue("IdEscuela",IdEscuela);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            escuela.IdEscuela = Convert.ToInt32(rd["IdRegistro"]);
                            escuela.Mensaje = rd["Mensaje"].ToString();
                        }
                    }
                }
                return escuela;
            }
            catch (Exception error)
            {
                return escuela;
            }
        }

    }
}
