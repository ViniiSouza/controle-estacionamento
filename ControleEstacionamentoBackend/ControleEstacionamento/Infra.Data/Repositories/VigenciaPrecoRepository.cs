using ControleEstacionamento.Domain.Entidades;
using ControleEstacionamento.Domain.Interfaces.Repositories;
using ControleEstacionamento.Infra.Data.Context;

namespace ControleEstacionamento.Infra.Data.Repositories
{
    public class VigenciaPrecoRepository : Repository<VigenciaPreco>, IVigenciaPrecoRepository
    {
        public VigenciaPrecoRepository(ControleEstacionamentoDbContext context) : base(context)
        {
        }

        public VigenciaPreco GetPorData(DateTime vigencia)
        {
            return _context.Set<VigenciaPreco>().Where(where => where.InicioVigencia <= vigencia && where.FimVigencia >= vigencia).FirstOrDefault();
        }
    }
}
