using Microsoft.AspNetCore.Mvc;
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

        private static List<Maquina> maquinas = new List<Maquina>();

        public List<Maquina> ConsultarTodos()
        {
            return maquinas.Where(m => m.Ativa).ToList();
        }
        
        public Maquina ConsultaPorCodigo(int codigo)
        {
            var Maquina = maquinas.FirstOrDefault(m => m.Codigo == codigo);
            if (Maquina == null)
                throw new Exception($"Máquina com código {codigo} não encontrada!");

            return Maquina;
        }

        public void Cadastrar(Maquina maquina)
        {
            maquinas.Add(maquina);
        }

        public bool Alterar(int codigo, Maquina novaMaquina)
        {
            var index = maquinas.FindIndex(m => m.Codigo == codigo);
            if (index != -1)
            {
                maquinas[index] = novaMaquina;
                return true;
            }
            return false;
        }

        public bool Deletar(int codigo)
        {
            var maquina = maquinas.FirstOrDefault(m => m.Codigo == codigo);
            if (maquina != null)
            {
                maquinas.Remove(maquina);
                return true;
            }
            return false;
        }

    }
}
