using ControleEstacionamento.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ControleEstacionamento.Infra.Data.Context
{
    public class ControleEstacionamentoDbContext : DbContext
    {
        public ControleEstacionamentoDbContext(DbContextOptions<ControleEstacionamentoDbContext> options) : base(options) { }

        public virtual DbSet<Carro> Carro { get; set; }
        public virtual DbSet<Registro> Registro { get; set; }
        public virtual DbSet<VigenciaPreco> VigenciaPreco { get; set; }
    }
}
