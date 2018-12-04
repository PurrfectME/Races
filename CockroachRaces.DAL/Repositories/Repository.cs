using System.Data.Entity;
using CockroachRaces.BLL.CommonInterfaces;
using CockroachRaces.DAL.EntitiesContext;

namespace CockroachRaces.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> _entity;
        private readonly ApplicationContext _context;

        public Repository(IDbSet<T> entity, ApplicationContext context)
        {
            _entity = entity;
            _context = context;
        }


        public void Create(T entity)
        {
            _entity.Add(entity);
        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
            
        }

        public void Update(T entity)
        {
            _entity.Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
