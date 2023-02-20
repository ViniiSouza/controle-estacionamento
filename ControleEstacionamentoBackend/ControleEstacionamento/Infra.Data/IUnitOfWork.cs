namespace ControleEstacionamento.Infra.Data
{
    public interface IUnitOfWork
    {
        void Commit();

        void Rollback();
    }
}
