using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoTeste.Model.Security
{
    [Table("Usuarios")]
    public class Login
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(10)]
        [Column("usuario")]
        public string Usuario { get; set; } = string.Empty;

        [Required]
        [MinLength(1), MaxLength(100)]
        [Column("senha")]
        public string Senha { get; set; } = string.Empty;

        public Login(int id, string usuario, string senha)
        {
            Id = id;
            Usuario = usuario;
            Senha = senha;
        }
    }
}