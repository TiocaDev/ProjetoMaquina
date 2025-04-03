using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.Model
{
    public class Lancamento
    {
        [Key]
        [Column("codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required]
        [Column("codigo_maquina")]
        public int CodigoMaquina { get; set; }
        [Required]
        [Column("maquina")]
        public string NomeMaquina { get; set; } = string.Empty;
        [Required]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Column("quantidade")]
        public int Quantidade { get; set; }
        
    }
}

