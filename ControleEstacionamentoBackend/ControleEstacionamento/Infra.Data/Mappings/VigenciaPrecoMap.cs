using ControleEstacionamento.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstacionamento.Infra.Data.Mappings
{
    public class VigenciaPrecoMap : IEntityTypeConfiguration<VigenciaPreco>
    {
        public void Configure(EntityTypeBuilder<VigenciaPreco> builder)
        {
            builder.HasKey(prop => prop.Id);
        }
    }
}
