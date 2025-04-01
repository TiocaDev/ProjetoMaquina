using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.DTO.Security
{
    public class LoginDTO
    {
        [Required]
        [MinLength(1), MaxLength(10)]
        public string Usuario { get; set; } = string.Empty;
        [Required]
        [MinLength(1), MaxLength(100)]
        public string Senha { get; set; } = string.Empty;

        public LoginDTO(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }
    }
}
