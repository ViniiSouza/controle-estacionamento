using ControleEstacionamento.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstacionamento.Infra.Data.Mappings
{
    public class RegistroMap : IEntityTypeConfiguration<Registro>
    {
        public void Configure(EntityTypeBuilder<Registro> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.HasOne(prop => prop.Carro)
                .WithMany()
                .HasForeignKey(prop => prop.CarroId);
        }
    }
}
