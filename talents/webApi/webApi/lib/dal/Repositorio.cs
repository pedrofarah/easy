using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using lib.interfaces;

namespace lib.dal
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private AppDbContext _contexto = null;
        private DbSet<T> _DbSet { get; set; }
        public Repositorio(AppDbContext context)
        {
            _contexto = context;
            _DbSet = _contexto.Set<T>();
        }
        public DbSet<T> DBSet { get { return _DbSet; } }
        public IEnumerable<T> Listar(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _DbSet.Where(predicate).AsNoTracking();
            }
            return _DbSet.AsNoTracking().AsEnumerable();
        }
        public virtual T Recuperar(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.FirstOrDefault(predicate);
        }
        public void Adicionar(T dto)
        {
            try
            {
                _DbSet.Add(dto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
            }
        }
        public virtual void Atualizar(T dto)
        {
            try
            {
                _DbSet.Update(dto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
            }
        }
        public void Excluir(T dto)
        {
            try
            {
                _DbSet.Remove(dto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
            }
        }

    }

}
