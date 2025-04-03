using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ProjetoTeste.Repositories.Security;
using ProjetoTeste.DTO.Security;
using ProjetoTeste.Model.Security;
using System.Text;

namespace ProjetoTeste.Services
{
    public record AutorizaToken(bool authenticar, DateTime expirar, string token, string descricao, bool authenticated)
    {
        public AutorizaToken(bool authenticated, string token, DateTime expirar, string descricao)
            : this(authenticated, expirar, token, descricao, authenticated)
        {
        }
    }

    public class TokenService
    {
        public AutorizaToken GeraToken(Login usuario, IConfiguration _configuration)
        {
            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Name, usuario.Usuario),
                    new Claim("codigo", usuario.Senha.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 };

            //gera uma chave com base em um algoritmo simetrico
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            //gera a assinatura digital do token usando o algoritmo Hmac e a chave privada
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Tempo de expiracão do token.
            var expiracao = _configuration["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));

            // classe que representa um token JWT e gera o token
            JwtSecurityToken token = new JwtSecurityToken(
              issuer: _configuration["TokenConfiguration:Issuer"],
              audience: _configuration["TokenConfiguration:Audience"],
              claims: claims,
              expires: expiration,
              signingCredentials: credenciais);

            //retorna os dados com o token e informacoes
            return new AutorizaToken(
                authenticated: true,
                token: new JwtSecurityTokenHandler().WriteToken(token),
                expirar: expiration,
                descricao: "Token JWT OK"
            );
        }
    }
}