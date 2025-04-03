using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.DTO.Security
{
    public class LoginDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(1), MaxLength(10)]
        public string Usuario { get; set; } = string.Empty;
        [Required]
        [MinLength(1), MaxLength(100)]
        public string Senha { get; set; } = string.Empty;

    }
}
