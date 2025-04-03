using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjetoTeste.DTO.Cadastros;

namespace ProjetoTeste.Model.Cadastro 
{ 
public class Maquina
{
    [Key]
    [Column("codigo")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    [Required]
    [Column("nome")]
    public string Nome { get; set; } = string.Empty;
    [Column("descricao")]
    public string? Descricao { get; set; }
    [Column("ativa")]
    public bool Ativa { get; set; }
    }

public class MaquinaConsulta
{
    [Column("codigo")]
    public int Codigo { get; set; }
    [Column("nome")]
    public string Nome { get; set; } = string.Empty;
    [Column("descricao")]
    public string? Descricao { get; set; }
}

public class MaquinaCadastrar
    {
        [Column("codigo")]
        public int Codigo { get; set; }
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;
        [Column("descricao")]
        public string? Descricao { get; set; }
        [Column("ativa")]
        public bool Ativa { get; set; }
    }

    public class MaquinaAlterar
    {
        [Column("codigo")]
        public int Codigo { get; set; }
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;
        [Column("descricao")]
        public string? Descricao { get; set; }
        [Column("ativa")]
        public bool Ativa { get; set; }
    }

}