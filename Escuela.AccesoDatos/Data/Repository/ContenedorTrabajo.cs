using Microsoft.Extensions.Configuration;
using Escuela.AccesoDatos.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        // Implementación de la interfaz IContenedorTrabajo
        // Aquí se pueden inicializar los repositorios y el contexto de la base de datos
        private readonly ApplicationDbContext _db; // Contexto de la base de datos
                                                   // Constructor que recibe el contexto de la base de datos
        private readonly IConfiguration _configuration; // Agregar el campo para IConfiguration
        public ContenedorTrabajo(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration; // Inicializar la configuración
            Escuela = new EscuelaRepository(_db, configuration);
            Alumno = new AlumnoRepository(_db, configuration);
            Profesor = new ProfesorRepository(_db, configuration);
            EscuelaProfesor = new EscuelaProfesorRepository(_db, configuration);
            Inscripcion= new InscripcionRepository(_db, configuration);
            ProfesorAlumno = new ProfesorAlumnoRepository(_db, configuration);
        }
        public IEscuelaRepository Escuela { get; set; }
        public IAlumnoRepository Alumno { get; set; }
        public IProfesorRepository Profesor { get; set; }
        public IEscuelaProfesor EscuelaProfesor { get; set; }
        public IInscripcionRepository Inscripcion { get; set; }
        public IProfesorAlumnoRepository ProfesorAlumno { get; set; }


        public void Dispose()
        {
            // Liberar recursos si es necesario
            _db.Dispose();
        }

        public void Save()
        {
            // Guardar los cambios en la base de datos
            _db.SaveChanges();
        }
    }
}