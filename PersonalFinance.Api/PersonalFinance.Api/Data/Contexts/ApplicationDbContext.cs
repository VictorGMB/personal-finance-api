using Microsoft.EntityFrameworkCore;
using PersonalFinance.Api.Models;

namespace PersonalFinance.Api.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        // Construtor que recebe as opções de configuração do DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        // Propriedades DbSet para as entidades do seu domínio
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        // Método para configurar o modelo do banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chamada base para garantir que o método da classe base seja executado
            base.OnModelCreating(modelBuilder);


            // Mapeamento do Enum ETransactionType
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Type)
                .HasConversion<int>();

            // Configuração: Um User pode ter várias Categories
            modelBuilder.Entity<User>()
                .HasMany(u => u.Categories)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            // Configuração: Um User pode ter várias Transactions
            modelBuilder.Entity<User>()
                .HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            // Configuração: Uma Category pode ter várias Transactions
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Category)
                .HasForeignKey(c => c.CategoryId);

            // Configura a entidade User para ter um índice único na coluna Email
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            // Configura a entidade User para mapear para a tabela "Users"
            modelBuilder.Entity<User>().ToTable("Users");

            // Configura a entidade Category para mapear para a tabela "Categories"
            modelBuilder.Entity<Category>().ToTable("Categories");

            // Configura a entidade Transaction para mapear para a tabela "Transactions"
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
        }
    }
}
