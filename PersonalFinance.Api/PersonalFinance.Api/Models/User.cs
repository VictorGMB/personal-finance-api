using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Api.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }    // Chave primária
        public required string Name { get; set; }   // Nome do usuário
        public required string Email { get; set; }  // Email do usuário
        public required string PasswordHash { get; set; }   // Hash da senha do usuário
        public DateTimeOffset CreatedAt { get; set; }   // Data de criação do usuário
        public ICollection<Category> Categories { get; set; } = new List<Category>(); // Propriedade de navegação com a classe Category
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>(); // Propriedade de navegação com a classe Transaction
    }
}
