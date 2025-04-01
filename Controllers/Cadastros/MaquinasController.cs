using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Model.Cadastro;
using System.Collections.Generic;
using ProjetoTeste.Repositories.Cadastros;
using ProjetoTeste.DTO.Cadastros;
using System.Threading.Tasks;

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
    public ActionResult Cadastrar([FromBody] MaquinaCadastrarDTO maquinaDTO)
    {
        MaquinaCadastrar maquinaCadastrar = new MaquinaCadastrar
        {            
            Nome = maquinaDTO.Nome,
            Descricao = maquinaDTO.Descricao,
            Ativa = maquinaDTO.Ativa
        };

        _repository.Cadastrar(maquinaCadastrar);
        return Ok("Máquina cadastrada com sucesso!");
    }

    /// <summary>
    /// Alterar uma Maquina
    /// </summary>
    [HttpPut("{codigo}")]
    public ActionResult Alterar(int codigo, [FromBody] MaquinaAlterarDTO maquinaAlterarDTO)
    {
        if (maquinaAlterarDTO == null)
            return BadRequest("Dados inválidos.");

        MaquinaAlterar maquinaAlterar = new MaquinaAlterar
        {           
            Nome = maquinaAlterarDTO.Nome,
            Descricao = maquinaAlterarDTO.Descricao,
            Ativa = maquinaAlterarDTO.Ativa
        };

        bool alterado = _repository.Alterar(codigo, maquinaAlterar);
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
