using ControleEstacionamento.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstacionamento.Infra.Data.Mappings
{
    public class CarroMap : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Placa).HasMaxLength(8);
        }
    }
}
