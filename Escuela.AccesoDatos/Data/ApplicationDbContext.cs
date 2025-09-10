using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Escuela.Modelos;

namespace Escuela.AccesoDatos.Data
{
    public class ApplicationDbContext : DbContext//IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //van los modelos de la base de datos
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Aquí puedes configurar tus modelos, relaciones, etc.
        //    // Por ejemplo:
        //    // builder.Entity<YourEntity>().ToTable("YourTableName");
        //}
        public DbSet<Modelos.Escuela> Escuela { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<EscuelaProfesor> EscuelaProfesor { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; }
        public DbSet<ProfesorAlumno> ProfesorAlumno { get; set; }
    }
    
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(@"Server=CANDYX\\SQL2019;Database=EscuelaMusica;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;User ID=sa;Password=SQL2019;Encrypt=False"); // Reemplaza con tu cadena de conexión
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    //{
    //    public ApplicationDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    //        optionsBuilder.UseSqlServer("ConexionSQL"); // O utiliza otra configuración específica

    //        return new ApplicationDbContext(optionsBuilder.Options);
    //    }
    //}
}

