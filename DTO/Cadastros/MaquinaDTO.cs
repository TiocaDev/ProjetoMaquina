using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.DTO.Cadastros
{   

        public class MaquinaCadastrarDTO
        {
        [Required]
        [MinLength(1)]
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        [Required]
        public bool Ativa { get; set; }

        }

        public class MaquinaAlterarDTO
        {
        [Required]
        [MinLength(1)]
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        [Required]
        public bool Ativa { get; set; }
        }

}