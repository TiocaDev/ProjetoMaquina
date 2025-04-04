using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.DTO;
using ProjetoTeste.Infra.Database;
using ProjetoTeste.Model;
using ProjetoTeste.Model.Cadastro;
using ProjetoTeste.Repositories;
using ProjetoTeste.Repositories.Cadastros;
using System;

namespace ProjetoTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentosController : ControllerBase
    {
        private readonly LancamentosRepository _repository;
        private readonly MaquinasRepository _maquinasRepository;

        public LancamentosController(LancamentosRepository repository, MaquinasRepository maquinasRepository)
        {
            _repository = repository;
            _maquinasRepository = maquinasRepository;
        }

        /// <summary>
        /// Cadastro de Lançamentos
        /// </summary>
        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> Cadastrar([FromBody] LancamentoDTO lancamentoDTO)
        {
            try
            {
                var maquina = await _maquinasRepository.ConsultaPorCodigo(lancamentoDTO.CodigoMaquina);
                if (maquina == null)
                    return NotFound("Máquina não encontrada.");

                // Obtém o ID do usuário a partir do JWT
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                    return Unauthorized(new { message = "Usuário não autenticado." });

                var lancamento = new Lancamento
                {
                    CodigoMaquina = lancamentoDTO.CodigoMaquina,
                    NomeMaquina = maquina.Nome,
                    IdUsuario = userId,
                    Quantidade = lancamentoDTO.Quantidade
                };

                var novoLancamento = await _repository.Cadastrar(lancamento);
                var itens = lancamentoDTO.Itens.Select(item => new LancamentoItem
                {
                    CodigoLancamento = novoLancamento.Codigo,
                    CodigoProduto = item.CodigoProduto,
                    Quantidade = item.Quantidade,
                    Unidade = item.Unidade
                }).ToList();

                await _repository.CadastrarItens(itens);

                return CreatedAtAction(nameof(Cadastrar), new { id = novoLancamento.Codigo }, novoLancamento);
            
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Ocorreu um erro ao processar a solicitação.",
                    detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Consulta dos Lançamentos
        /// </summary>
        [Authorize]
        [HttpGet()]
        public async Task<IActionResult> ConsultarTodos()
        {
            try
            {
                var lancamentos = await _repository.ConsultarTodos();
                return Ok(lancamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Ocorreu um erro ao processar a solicitação",
                    detail = ex.Message
                });
            }

        }

        /// <summary>
        /// Consulta de Lançamento por código
        /// </summary>
        [Authorize]
        [HttpGet("{codigo}")]
        public async Task<IActionResult> ConsultarPorCodigo(int codigo)
        {
            try
            {
                var lancamento = await _repository.ConsultarPorCodigo(codigo);
                if (lancamento == null)
                    return NotFound("Lançamento não encontrado.");

                return Ok(lancamento);
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    message = "Ocorreu um erro ao processar a solicitação",
                    detail = ex.Message
                });
            }

        }

        /// <summary>
        /// Consulta de item por código
        /// </summary>
        [Authorize]
        [HttpGet("{codigo}/item")]
        public async Task<IActionResult> ConsultarPorCodigoComItens(int codigo)
        {
            try
            {
                var lancamento = await _repository.ConsultarPorCodigoComItens(codigo);
                if (lancamento == null)
                    return NotFound("Lançamento não encontrado");

                var resultado = new LancamentoDetalhadoDTO
                {
                    Codigo = lancamento.Codigo,
                    CodigoMaquina = lancamento.CodigoMaquina,
                    Quantidade = lancamento.Quantidade,
                    Itens = lancamento.Itens.Select(item => new LancamentoItemDTO
                    {
                        CodigoProduto = item.CodigoProduto,
                        Quantidade = item.Quantidade,
                        Unidade = item.Unidade
                    }).ToList()
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Ocorreu um erro ao processar a solicitação",
                    detail = ex.Message
                });
            }

        }
    }
}
