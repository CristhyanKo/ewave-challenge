using Bibliotech.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibliotech.Infra.Data.Mapping
{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(column => column.Id);

            builder.Property(column => column.Nome).IsRequired();
            builder.Property(column => column.DataNascimento).IsRequired();
        }
    }
}