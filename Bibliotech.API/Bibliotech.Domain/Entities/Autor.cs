using System;
namespace Bibliotech.Domain.Entites
{
    public class Autor : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Biografia { get; set; }
    }
}