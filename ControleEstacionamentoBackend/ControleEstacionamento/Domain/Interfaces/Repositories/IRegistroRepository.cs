using ControleEstacionamento.Domain.Entidades;

namespace ControleEstacionamento.Domain.Interfaces.Repositories
{
    public interface IRegistroRepository : IRepository<Registro>
    {
        Registro GetPorPlacaCarroSemHoraSaida(string placaCarro);
    }
}
