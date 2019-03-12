
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace lib.interfaces
{
    public delegate void validar<T>(T sender) where T : class;
    public interface INegocio<T> where T : class
    {
        INucleoDados NucleoDados { get; set; }
        event validar<T> ValidacaoAdicionar;
        void Adicionar(T dto);
        event validar<T> ValidacaoAtualizar;
        void Atualizar(T dto);
        event validar<T> ValidacaoExcluir;
        void Excluir(T dto);
        IEnumerable<T> Listar(Expression<Func<T, bool>> predicate = null);
        T Recuperar(Expression<Func<T, bool>> predicate);
    }

}
