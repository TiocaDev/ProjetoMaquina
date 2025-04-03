using Microsoft.EntityFrameworkCore;
using ProjetoTeste.DTO.Security;
using ProjetoTeste.Infra.Database;
using ProjetoTeste.Model.Security;
using System.Collections.Generic;
using System.Linq;


namespace ProjetoTeste.Repositories.Security
{
    public class AuthRepository
    {
        private readonly ProjetoTesteContext _context;

        public AuthRepository(ProjetoTesteContext context)
        {
            _context = context;

            
        }

        public Login ConsultaPeloLogin(int id, string usuario, string senha)
        {
            return _context.usuarios.FirstOrDefault(u => u.Usuario == usuario && u.Senha == senha);
        }

        private readonly List<Login> _usuarios;

        
    }
}
