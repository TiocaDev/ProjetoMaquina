using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Infra.Database;
using ProjetoTeste.Model.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoTeste.Repositories.Cadastros
{
        public class MaquinasRepository
    {

        private readonly ProjetoTesteContext _context;

        public MaquinasRepository(ProjetoTesteContext context)
        {
            _context = context;
        }

        public async Task<List<Maquina>> ConsultarTodos()
        {
            return await _context.maquinas.ToListAsync();
        }

        public async Task<Maquina> ConsultaPorCodigo(int codigo)
        {
            return await _context.maquinas.FindAsync(codigo);
        }

        public async Task Cadastrar(Maquina maquina)
        {
            await _context.maquinas.AddAsync(maquina);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(Maquina maquina)
        {
            _context.maquinas.Update(maquina);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(int codigo)
        {
            var maquina = await _context.maquinas.FindAsync(codigo);
            if (maquina != null)
            {
                _context.maquinas.Remove(maquina);
                await _context.SaveChangesAsync();
            }
        }

    }
}
