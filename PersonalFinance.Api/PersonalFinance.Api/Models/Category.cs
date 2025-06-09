using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Api.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }    // Chave primária
        public required string Title { get; set; }  // Título da categoria
        public string? Description { get; set; }    // Descrição da categoria
        public Guid UserId { get; set; }    // Chave estrangeira para a classe User
        public User User { get; set; } = null!; // Propriedade de navegação com a classe User
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>(); // Propriedade de navegação com a classe Transaction
    }
}
