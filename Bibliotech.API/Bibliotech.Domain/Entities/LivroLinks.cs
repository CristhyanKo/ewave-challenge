namespace Bibliotech.Domain.Entites
{
    public class LivroLinks : BaseEntity
    {
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public string Link { get; set; }
    }
}