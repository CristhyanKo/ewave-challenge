using Bibliotech.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibliotech.Infra.Data.Mapping
{
    public class LivroLinksMap : IEntityTypeConfiguration<LivroLinks>
    {
        public void Configure(EntityTypeBuilder<LivroLinks> builder)
        {
            builder.ToTable("LivroLinks");
            builder.HasKey(column => column.Id);

            builder.Property(column => column.Link).IsRequired();
            builder.Property(column => column.LivroId).IsRequired();
        }
    }
}