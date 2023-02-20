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

        public Registro GetPorPlacaCarroSemHoraSaida(string placaCarro)
        {
            return _context.Set<Registro>().Where(where => where.Carro.Placa == placaCarro && where.HorarioSaida == null)
                .Include(include => include.Carro).FirstOrDefault();
        }
    }
}
