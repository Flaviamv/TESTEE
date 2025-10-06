using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Repositorio;


namespace SistemVenda.Repositorio.Entidades 
{
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override void Delete(int id)
        {
            var listaProdutos = _dbSet.Include(x => x.Produtos).
            Where(y => y.Codigo == id).Select(z => z.Produtos).ToList();

            VendaProduto vendaproduto;
            foreach (var item in listaProdutos)
            {

                foreach (var produto in item)
                {
                    vendaproduto = new VendaProduto();
                    {
                        vendaproduto.CodigoVenda = id;
                        vendaproduto.CodigoProduto = produto.CodigoProduto;
                    }
                ;

                    DbSet<VendaProduto> DbSetAux;
                    DbSetAux = _db.Set<VendaProduto>();
                    DbSetAux.Attach(vendaproduto);
                    DbSetAux.Remove(vendaproduto);
                    _db.SaveChanges();
                }
                
            }

           

            base.Delete(id);
        }

    }
}
