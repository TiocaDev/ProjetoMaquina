using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.DTO.Cadastros
{
    public class MaquinaDTO
    {

        public class MaquinaCadastrarDTO
        {

            public int Codigo { get; set; }
            public string Nome { get; set; } = string.Empty;
            public string? Descricao { get; set; }
            public bool Ativa { get; set; }

        }

        public class MaquinaAlterarDTO
        {
            public int Codigo { get; set; }
            public string Nome { get; set; } = string.Empty;
            public string? Descricao { get; set; }
            public bool Ativa { get; set; }
        }
    }
}
