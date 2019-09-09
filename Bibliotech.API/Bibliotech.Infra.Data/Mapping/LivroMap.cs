using Bibliotech.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibliotech.Infra.Data.Mapping
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(column => column.Id);

            builder.Property(column => column.Titulo).IsRequired();
            builder.Property(column => column.DataPublicacao).IsRequired();
            builder.Property(column => column.Paginas).IsRequired();
            builder.Property(column => column.AutorId).IsRequired();
            builder.Property(column => column.EditoraId).IsRequired();
            builder.Property(column => column.Descricao).IsRequired();
            builder.Property(column => column.Sinopse).IsRequired();
            builder.Property(column => column.Capa).IsRequired();
        }
    }
}