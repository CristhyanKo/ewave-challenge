using Bibliotech.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibliotech.Infra.Data.Mapping
{
    public class GeneroMap : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Genero");
            builder.HasKey(column => column.Id);

            builder.Property(column => column.Descricao).IsRequired();
        }
    }
}