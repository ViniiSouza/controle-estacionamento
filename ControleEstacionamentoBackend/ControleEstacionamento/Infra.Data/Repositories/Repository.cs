using ControleEstacionamento.Domain.Entidades;
using ControleEstacionamento.Domain.Interfaces.Repositories;
using ControleEstacionamento.Infra.Data.Context;

namespace ControleEstacionamento.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntidadeBase
    {
        internal readonly ControleEstacionamentoDbContext _context;

        public Repository(ControleEstacionamentoDbContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
        public virtual T GetById(int id)
        {
            return _context.Set<T>().Where(where => where.Id == id).FirstOrDefault();
        }

        public virtual T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
        }
    }
}
