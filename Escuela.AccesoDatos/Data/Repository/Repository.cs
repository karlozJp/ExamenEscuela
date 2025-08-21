using Escuela.AccesoDatos.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Escuela.AccesoDatos.Data.Repository
{
    //clase que mplementa el patron repositorio para acceder a los datos de la base de datos
    public class Repository<T> : IRepository<T> where T : class //T es parametro de tipo generico que hereda de class
    {
        private readonly IConfiguration _configuration;
        protected readonly DbContext Context; //contexto de la base de datos
        internal DbSet<T> dbSet; //conjunto de entidades de tipo T    
        public Repository(DbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            this.Context = context ?? throw new ArgumentNullException(nameof(context)); //si el contexto es nulo, lanza una excepcion
            dbSet = context.Set<T>(); //inicializa el conjunto de entidades de tipo T
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            dbSet.Add(entity); //agrega la entidad al conjunto de entidades
        }

        public T Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero");
            }
            return dbSet.Find(id); //busca la entidad por id
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet; //inicializa la consulta con el conjunto de entidades
            if (filter != null)
            {
                query = query.Where(filter); //aplica el filtro si se proporciona
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty); //incluye las propiedades especificadas
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList(); //aplica el ordenamiento si se proporciona y devuelve la lista
            }
            return query.ToList(); //devuelve la lista de entidades
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet; //inicializa la consulta con el conjunto de entidades
            if (filter != null)
            {
                query = query.Where(filter); //aplica el filtro si se proporciona
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty); //incluye las propiedades especificadas
                }
            }
            return query.FirstOrDefault(); //devuelve el primer elemento que cumple con el filtro o null si no hay ninguno
        }

        public void Remove(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero");
            }
            T entity = dbSet.Find(id); //busca la entidad por id
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity); //adjunta la entidad al contexto si esta separada
            }
            dbSet.Remove(entity); //elimina la entidad del conjunto de entidades            
        }
        
    }
}
