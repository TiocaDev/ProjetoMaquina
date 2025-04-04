using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph.Models.ExternalConnectors;
using Npgsql;
using ProjetoTeste.Infra.Database;
using ProjetoTeste.Model;
using System;


namespace ProjetoTeste.Repositories
{
    public class LancamentosRepository
    {
        private readonly ProjetoTesteContext _context;
        private readonly IConfiguration _configuration;

        public LancamentosRepository(ProjetoTesteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Lancamento> Cadastrar(Lancamento lancamento)
        {
            _context.lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<List<Lancamento>> ConsultarTodos()
        {
            return await _context.lancamentos.ToListAsync();
        }

        public async Task<Lancamento> ConsultarPorCodigo(int codigo)
        {
            return await _context.lancamentos.FirstOrDefaultAsync(l => l.Codigo == codigo);
        }

        public async Task CadastrarItens(List<LancamentoItem> itens)
        {
            await _context.LancamentosItens.AddRangeAsync(itens);
            await _context.SaveChangesAsync();
        }

        public async Task<Lancamento?> ConsultarPorCodigoComItens(int codigo)
        {
            var lancamento = await _context.lancamentos
                .Include(l => l.Itens)
                .FirstOrDefaultAsync(l => l.Codigo == codigo);

            return lancamento;
        }

        public async Task<List<LancamentoResumo>> ConsultarResumoPorCodigo(int codigo)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            var lista = new List<LancamentoResumo>();

            using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            var sql = @"
            SELECT 
                codigo_lancamento AS CodigoLancamento, 
                unidade AS Unidade, 
                SUM(quantidade) AS Quantidade
            FROM lancamentos_itens
            WHERE codigo_lancamento = @codigo
            GROUP BY codigo_lancamento, unidade;";

            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@codigo", codigo);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var item = new LancamentoResumo
                {
                    CodigoLancamento = reader.GetInt32(0),
                    Unidade = reader.GetString(1),
                    Quantidade = reader.GetInt32(2)
                };

                lista.Add(item);
            }

            return lista;
        }
    
    }
}
