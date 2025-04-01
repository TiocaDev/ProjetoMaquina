using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjetoTeste.DTO.Cadastros;

namespace ProjetoTeste.Model.Cadastro 
{ 
public class Maquina
{
    public int Codigo { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public bool Ativa { get; set; }
    }

public class MaquinaConsulta
{
    public int Codigo { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
}

public class MaquinaCadastrar
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public bool Ativa { get; set; }
    }

    public class MaquinaAlterar
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public bool Ativa { get; set; }
    }

}