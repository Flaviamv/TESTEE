using SistemVenda.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IServicosCategoria
    {
        IEnumerable<Categoria> Listagem();
        void Cadastrar(Categoria categoria);
        Categoria CarregarRegistro(int id);
        void Excluir(int id);
    
    }
}
