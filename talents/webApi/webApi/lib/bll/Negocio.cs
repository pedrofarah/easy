using lib.interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace lib.bll
{
    
    public class Negocio<T> : INegocio<T> where T : class
    {
        public INucleoDados NucleoDados { get; set; }

        public Negocio(INucleoDados _nucleoDados)
        {
            NucleoDados = _nucleoDados;
        }

        public event validar<T> ValidacaoAdicionar;

        public void Adicionar(T dto)
        {
            try
            {
                if (ValidacaoAdicionar == null)
                    throw new NotImplementedException();

                ValidacaoAdicionar?.Invoke(dto);

                NucleoDados.Gravar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        public event validar<T> ValidacaoAtualizar;
        public void Atualizar(T dto)
        {
            try
            {
                if (ValidacaoAtualizar == null)
                    throw new NotImplementedException();

                ValidacaoAtualizar.Invoke(dto);

                NucleoDados.Gravar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        public event validar<T> ValidacaoExcluir;
        public void Excluir(T dto)
        {
            try
            {
                if (ValidacaoExcluir == null)
                    throw new NotImplementedException();

                ValidacaoExcluir?.Invoke(dto);

                NucleoDados.Gravar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        public virtual IEnumerable<T> Listar(Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public virtual T Recuperar(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

    }

}
