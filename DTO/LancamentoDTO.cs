using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.DTO
{
    public class LancamentoDTO
    {
        [Required]
        public int CodigoMaquina { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public required List<LancamentoItemDTO> Itens { get; set; } 
    }

    public class LancamentoItemDTO
    {
        [Required]
        public int CodigoProduto { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public string Unidade { get; set; } = string.Empty;
    }

    public class LancamentoDetalhadoDTO
    {
        public int Codigo { get; set; }
        public int CodigoMaquina { get; set; }
        public int Quantidade { get; set; }
        public List<LancamentoItemDTO> Itens { get; set; } = new();
    }
}
