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
        public List<LancamentoItem> Itens { get; set; } = new();

    }

    public class LancamentoItem
    {
        [Key]
        [Column("codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required]
        [Column("codigo_lancamento")]
        public int CodigoLancamento { get; set; }
        [Required]
        [Column("codigo_produto")]
        public int CodigoProduto { get; set; }
        [Required]
        [Column("quantidade")]
        public int Quantidade { get; set; }
        [Required]
        [Column("unidade")]
        public string Unidade { get; set; } = string.Empty;
    }

    public class LancamentoResumo
    {
        public int CodigoLancamento { get; set; }
        public string Unidade { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }
}

