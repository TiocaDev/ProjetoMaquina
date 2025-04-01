using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Repositories.Security;
using ProjetoTeste.DTO.Security;   
using ProjetoTeste.Model.Security;
using ProjetoTeste.Services;

namespace ProjetoTeste.Controllers.Security
{

    //[Route("api/Security/[controller]")]
    [Route("api/Security/Auth")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _repository;
        private readonly TokenService _tokenService;
        private IConfiguration _configuration;
        public AuthController(AuthRepository repository, TokenService tokenService, IConfiguration configuration)
        {
            _repository = repository;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        /// <summary>
        /// Rota anônima para realizar o login
        /// </summary>
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            if (login == null || string.IsNullOrEmpty(login.Usuario) || string.IsNullOrEmpty(login.Senha))
            {
                return BadRequest("Usuário e senha são obrigatórios.");
            }

            var usuario = _repository.ConsultaPeloLogin(login.Usuario, login.Senha);
            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos!");

            var token = _tokenService.GeraToken(usuario, _configuration);

            return Ok(token);
        }
    }
}