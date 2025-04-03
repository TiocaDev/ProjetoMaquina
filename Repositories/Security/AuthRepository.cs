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

            //_usuarios = new List<Login>
            //{
            //    new Login("1", "admin", "admin"),
            //    new Login("teste", "teste")
            //};
        }

        public Login ConsultaPeloLogin(int id, string usuario, string senha)
        {
            return _context.usuarios.FirstOrDefault(u => u.Usuario == usuario && u.Senha == senha);
        }

        private readonly List<Login> _usuarios;

        //public AuthRepository()
        //{
        //    // teste
        //    _usuarios = new List<Login>
        //    {
        //        new Login("admin", "admin"),
        //        new Login("teste", "teste")
        //    };
        //}

        ///// <summary>
        ///// Consulta um usuário pelo login e senha
        ///// </summary>
        //public Login? ConsultaPeloLogin(string usuario, string senha)
        //{
        //    return _usuarios.FirstOrDefault(u => u.Usuario == usuario && u.Senha == senha);
        //}
    }
}
