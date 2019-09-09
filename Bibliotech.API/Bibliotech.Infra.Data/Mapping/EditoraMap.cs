using Bibliotech.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibliotech.Infra.Data.Mapping
{
    public class EditoraMap : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder.ToTable("Editora");
            builder.HasKey(column => column.Id);

            builder.Property(column => column.Nome).IsRequired();
        }
    }
}