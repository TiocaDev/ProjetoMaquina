using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Model.Cadastro;
using System.Collections.Generic;
using ProjetoTeste.Repositories.Cadastros;
using ProjetoTeste.DTO.Cadastros;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
///[AllowAnonymous]
public class MaquinasController : ControllerBase
{
    private readonly MaquinasRepository _repository;

    public MaquinasController(MaquinasRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Consulta das Maquinas Ativas
    /// </summary>
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Maquina>>> GetAtivas()
    {
        return Ok(await _repository.ConsultarTodos());
    }

    /// <summary>
    /// Consulta Maquinas por código
    /// </summary>
    [Authorize]
    [HttpGet("{codigo}")]
    public async Task<ActionResult<Maquina>> PorCodigo(int codigo)
    {
        var maquina = await _repository.ConsultaPorCodigo(codigo);
        if (maquina == null)
            return NotFound();
        return Ok(maquina);
    }

    /// <summary>
    /// Cadastrar uma Maquina
    /// </summary>
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Cadastrar([FromBody] MaquinaCadastrarDTO maquinaDTO)
    {
        var maquina = new Maquina
        {
            Nome = maquinaDTO.Nome,
            Descricao = maquinaDTO.Descricao,
            Ativa = maquinaDTO.Ativa,
            Codigo = maquinaDTO.Codigo
        };

        await _repository.Cadastrar(maquina);
        return CreatedAtAction(nameof(PorCodigo), new { codigo = maquina.Codigo }, maquina);
    }

    /// <summary>
    /// Alterar uma Maquina
    /// </summary>
    [Authorize]
    [HttpPut("{codigo}")]
    public async Task<ActionResult> Alterar(int codigo, [FromBody] MaquinaAlterarDTO maquinaAlterarDTO)
    {
        if (codigo != maquinaAlterarDTO.Codigo)
            return BadRequest("Dados inválidos");

        var maquina = new Maquina
        {
            Nome = maquinaAlterarDTO.Nome,
            Descricao = maquinaAlterarDTO.Descricao,
            Ativa = maquinaAlterarDTO.Ativa,
            Codigo = maquinaAlterarDTO.Codigo
        };

        await _repository.Alterar(maquina);
        return NoContent();
    }

    /// <summary>
    /// Remove uma máquina pelo código
    /// </summary>
    [Authorize]
    [HttpDelete("{codigo}")]
    public async Task<ActionResult> Deletar(int codigo)
    {
        await _repository.Deletar(codigo);
        return NoContent();
    }

}
