using ControleEstacionamento.Infra.Data.Context;

namespace ControleEstacionamento.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ControleEstacionamentoDbContext _context;

        public UnitOfWork(ControleEstacionamentoDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // doNothing
        }
    }
}
