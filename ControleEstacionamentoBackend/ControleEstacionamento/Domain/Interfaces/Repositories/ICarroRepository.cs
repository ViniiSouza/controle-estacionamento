using ControleEstacionamento.Domain.Entidades;

namespace ControleEstacionamento.Domain.Interfaces.Repositories
{
    public interface ICarroRepository : IRepository<Carro>
    {
        Carro GetPorPlaca(string placa);
    }
}
