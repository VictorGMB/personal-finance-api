using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Api.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
