using ControleEstacionamento.Domain.Entidades;
using ControleEstacionamento.Domain.Interfaces.Repositories;
using ControleEstacionamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleEstacionamento.Infra.Data.Repositories
{
    public class RegistroRepository : Repository<Registro>, IRegistroRepository
    {
        public RegistroRepository(ControleEstacionamentoDbContext context) : base(context)
        {
        }

        public override IQueryable<Registro> GetAll()
        {
            return _context.Set<Registro>().Include(include => include.Carro);
        }
    }
}
