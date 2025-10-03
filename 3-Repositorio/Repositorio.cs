using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dominio.Repositorio;
using SistemVenda.Dominio.Entidade;
using Microsoft.EntityFrameworkCore.Storage;

namespace Repositorio
{
    public abstract class Repositorio<T> : IRepositorio<T>
    where T : EntityBase, new()
    {
        protected readonly DbContext _db;
        protected readonly DbSet<T> _dbSet;

        public Repositorio(DbContext dbContext)
        {
            _db = dbContext;
            _dbSet = _db.Set<T>();
        }

        public void Create(T entity)
        {
            if (entity.Codigo == null)
            {
                _dbSet.Add(entity);
            }
            else
            {
                _db.Entry(entity).State = EntityState.Modified;
            }
            _db.SaveChanges();

            // _dbSet.Add(entity); //  o prof fez if e else no lugar
            // _db.SaveChanges();
        }


        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _db.SaveChanges();
            }
        }

        public T Read(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> Read()
        {
            return _dbSet.AsNoTracking().ToList();
        }
    }
}

