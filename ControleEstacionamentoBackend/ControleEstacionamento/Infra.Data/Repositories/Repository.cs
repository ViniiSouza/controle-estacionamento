using ControleEstacionamento.Domain.Entidades;
using ControleEstacionamento.Domain.Interfaces;
using ControleEstacionamento.Infra.Data.Context;

namespace ControleEstacionamento.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntidadeBase
    {
        private readonly ControleEstacionamentoDbContext _context;

        public Repository(ControleEstacionamentoDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Where(where => where.Id == id).FirstOrDefault();
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
        }
    }
}
