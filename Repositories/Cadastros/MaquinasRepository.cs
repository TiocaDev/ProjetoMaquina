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


        //private static List<Maquina> maquinas = new List<Maquina>();

        //public List<Maquina> ConsultarTodos()
        //{
        //    return maquinas.Where(m => m.Ativa).ToList();
        //}

        //public Maquina? ConsultaPorCodigo(int codigo)
        //{
        //    return maquinas.FirstOrDefault(m => m.Codigo == codigo);
        //}

        //public void Cadastrar(MaquinaCadastrar maquinaCadastrar)
        //{
        //    var maquina = new Maquina
        //    {
        //        Codigo = maquinaCadastrar.Codigo,
        //        Nome = maquinaCadastrar.Nome,
        //        Descricao = maquinaCadastrar.Descricao,
        //        Ativa = maquinaCadastrar.Ativa
        //    };
        //    maquinas.Add(maquina);
        //}

        //public bool Alterar(int codigo, MaquinaAlterar maquinaAlterar)
        //{
        //    var index = maquinas.FindIndex(m => m.Codigo == codigo);
        //    if (index != -1)
        //    {
        //        var maquina = new Maquina
        //        {
        //            Codigo = maquinaAlterar.Codigo,
        //            Nome = maquinaAlterar.Nome,
        //            Descricao = maquinaAlterar.Descricao,
        //            Ativa = maquinaAlterar.Ativa
        //        };
        //        maquinas[index] = maquina;
        //        return true;
        //    }
        //    return false;
        //}

        //public bool Deletar(int codigo)
        //{
        //    var maquina = maquinas.FirstOrDefault(m => m.Codigo == codigo);
        //    if (maquina != null)
        //    {
        //        maquinas.Remove(maquina);
        //        return true;
        //    }
        //    return false;
        //}

    }
}
