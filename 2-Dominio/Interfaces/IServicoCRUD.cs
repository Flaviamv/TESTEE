using System;
using System.Collections.Generic;
using System.Text;

namespace SistemVenda.Dominio.Interfaces
{
    public interface IServicoCRUD<TEntidade>
    where TEntidade : class
    {
         IEnumerable<TEntidade> Listagem();
        void Cadastrar(TEntidade registro);
        TEntidade CarregarRegistro(int id);
        void Excluir(int id);
    }
}