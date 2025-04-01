using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Model.Cadastro;
using System.Collections.Generic;
using ProjetoTeste.Repositories.Cadastros;

[Route("api/[controller]")]
[ApiController]
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
    [HttpGet]
    public ActionResult<List<Maquina>> GetAtivas()
    {
        return Ok(_repository.ConsultarTodos());
    }

    /// <summary>
    /// Consulta Maquinas por código
    /// </summary>
    [HttpGet("{codigo}")]
    public ActionResult<Maquina> PorCodigo(int codigo)
    {
        var maquina = _repository.ConsultaPorCodigo(codigo);
        if (maquina == null)
            return NotFound("Máquina não encontrada.");

        return Ok(maquina);
    }

    /// <summary>
    /// Cadastrar uma Maquina
    /// </summary>
    [HttpPost]
    public ActionResult Cadastrar([FromBody] Maquina maquina)
    {
        if (maquina == null)
            return BadRequest("Dados inválidos.");

        _repository.Cadastrar(maquina);
        return CreatedAtAction(nameof(PorCodigo), new { codigo = maquina.Codigo }, maquina);
    }

    /// <summary>
    /// Alterar uma Maquina
    /// </summary>
    [HttpPut("{codigo}")]
    public ActionResult Alterar(int codigo, [FromBody] Maquina novaMaquina)
    {
        if (novaMaquina == null)
            return BadRequest("Dados inválidos.");

        bool alterado = _repository.Alterar(codigo, novaMaquina);
        if (!alterado)
            return NotFound("Máquina não encontrada.");

        return NoContent();
    }

    /// <summary>
    /// Remove uma máquina pelo código
    /// </summary>
    [HttpDelete("{codigo}")]
    public ActionResult Deletar(int codigo)
    {
        bool deletado = _repository.Deletar(codigo);
        if (!deletado)
            return NotFound("Máquina não encontrada.");

        return NoContent();
    }
}
