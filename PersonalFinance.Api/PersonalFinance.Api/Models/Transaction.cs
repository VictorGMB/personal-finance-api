using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Api.Models
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; } // Chave primária
        public required string Title { get; set; } // Título da transação
        public required decimal Amount { get; set; } // Valor da transação
        public ETransactionType Type { get; set; } // Tipo de transação (receita ou despesa)
        public DateTime CreatedAt { get; set; } // Data de criação da transação
        public Guid UserId { get; set; } // Chave estrangeira para a classe User
        public Guid CategoryId { get; set; } // Chave estrangeira para a classe Category
        public User User { get; set; } = null!; // Propriedade de navegação com a classe User
        public Category Category { get; set; } = null!; // Propriedade de navegação com a classe Category
    }
}
