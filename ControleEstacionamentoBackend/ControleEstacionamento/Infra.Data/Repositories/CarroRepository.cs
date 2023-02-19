using ControleEstacionamento.Domain.Entidades;
using ControleEstacionamento.Domain.Interfaces.Repositories;
using ControleEstacionamento.Infra.Data.Context;

namespace ControleEstacionamento.Infra.Data.Repositories
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public CarroRepository(ControleEstacionamentoDbContext context) : base(context)
        {
        }

        public Carro GetPorPlaca(string placa)
        {
            return _context.Set<Carro>().Where(where => where.Placa == placa).FirstOrDefault();
        }
    }
}
