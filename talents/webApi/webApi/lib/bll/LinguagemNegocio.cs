using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using lib.dto;
using lib.interfaces;

namespace lib.bll
{
    public class LinguagemNegocio : Negocio<Linguagem>
    {

        public LinguagemNegocio(INucleoDados _nucleoDados) : base(_nucleoDados)
        {
            NucleoDados = _nucleoDados;

            ValidacaoAdicionar += (sender) =>
            {
                try
                {
                    Validar(sender);
                    NucleoDados.LinguagemRepositorio.Adicionar(sender);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
                }
            };

            ValidacaoAtualizar += (sender) =>
            {
                try
                {
                    Validar(sender);
                    NucleoDados.LinguagemRepositorio.Atualizar(sender);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
                }
            };

            ValidacaoExcluir += (sender) =>
            {
                try
                {
                    Validar(sender, true);

                    Linguagem _cand = NucleoDados.LinguagemRepositorio.Recuperar(p => p.Id == sender.Id)
                        ?? throw new Exception("Registro não localizado. Impossível excluir.");

                    NucleoDados.LinguagemRepositorio.Excluir(_cand);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
                }
            };

        }

        private void Validar(Linguagem sender, bool Exclusao = false)
        {
            if (sender == null)
                throw new Exception("Dados inválidos.");
            if (Exclusao)
                if ((sender?.Id ?? 0) == 0)
                    throw new Exception("Id não informado.");
            if (!Exclusao)
                if ((sender?.Nome ?? string.Empty).Length == 0)
                    throw new Exception("Nome não informado.");
        }

        public override IEnumerable<Linguagem> Listar(Expression<Func<Linguagem, bool>> predicate = null)
        {
            return NucleoDados.LinguagemRepositorio.Listar(predicate);
        }

        public override Linguagem Recuperar(Expression<Func<Linguagem, bool>> predicate)
        {
            return NucleoDados.LinguagemRepositorio.Recuperar(predicate);
        }
    }
}
