using ControleEstacionamento.Domain.Entidades;

namespace ControleEstacionamento.Domain.Interfaces.Services
{
    public interface IBaseAppService<TEntity, TDto> where TEntity : EntidadeBase where TDto : class
    {
        List<TDto> GetAll();

        TDto GetById(int id);

        TDto Create(TDto dto);

        TDto Update(TDto dto);

        void Delete(int id);
    }
}
