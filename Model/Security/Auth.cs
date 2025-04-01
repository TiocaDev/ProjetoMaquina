using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.Model.Security
{
    public class Login
    {
        [Required]
        [MinLength(1), MaxLength(10)]
        public string Usuario { get; set; } = string.Empty;

        [Required]
        [MinLength(1), MaxLength(100)]
        public string Senha { get; set; } = string.Empty;

        public Login(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }
    }
}
