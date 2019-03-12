using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace lib.interfaces
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> Listar(Expression<Func<T, bool>> predicate = null);
        T Recuperar(Expression<Func<T, bool>> predicate);
        void Adicionar(T dto);
        void Atualizar(T dto);
        void Excluir(T dto);
    }
}
