    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Dominio.Repositorio;

    namespace Repositorio
    {
        public abstract class Repositorio<T> : IRepositorio<T> where T : class
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
                _dbSet.Add(entity);
                _db.SaveChanges();
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

            public IEnumerable<T> Read()
            {
                return _dbSet.AsNoTracking().ToList();
            }
        }
    }