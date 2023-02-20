using ControleEstacionamento.Domain.Entidades;

namespace ControleEstacionamento.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntidadeBase
    {
        /// <summary>
        /// Realiza a busca de todos os registros da entidade
        /// </summary>
        /// <returns>Uma query com todos os registros da entidade</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Realiza a busca da entidade do <paramref name="id"/> informado
        /// </summary>
        /// <param name="id">Id da entidade a buscar</param>
        /// <returns>A entidade do <paramref name="id"/> informado</returns>
        T GetById(int id);

        /// <summary>
        /// Cria a entidade passada no parâmetro
        /// </summary>
        /// <param name="entity">Entidade a criar</param>
        /// <returns>Retorna a entidade criada</returns>
        T Create(T entity);

        /// <summary>
        /// Atualiza a entidade passada no parâmetro
        /// </summary>
        /// <param name="entity">Entidade a atualizar</param>
        /// <returns>Retorna a entidade atualizada</returns>
        T Update(T entity);

        /// <summary>
        /// Realiza a exclusão da entidade do <paramref name="id"/> informado
        /// </summary>
        /// <param name="id">Id da entidade a excluir</param>
        void Delete(int id);
    }
}
