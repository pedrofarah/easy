using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using lib.dto;
using lib.interfaces;

namespace lib.bll
{
    public class DisponibilidadePeriodoNegocio : Negocio<DisponibilidadePeriodo>
    {

        public DisponibilidadePeriodoNegocio(INucleoDados _nucleoDados) : base(_nucleoDados)
        {
            NucleoDados = _nucleoDados;

            ValidacaoAdicionar += (sender) =>
            {
                try
                {
                    Validar(sender);
                    NucleoDados.DisponibilidadePeriodoRepositorio.Adicionar(sender);
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
                    NucleoDados.DisponibilidadePeriodoRepositorio.Atualizar(sender);
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

                    DisponibilidadePeriodo obj = NucleoDados.DisponibilidadePeriodoRepositorio.Recuperar(p => p.Id == sender.Id)
                        ?? throw new Exception("Registro não localizado. Impossível excluir.");

                    NucleoDados.DisponibilidadePeriodoRepositorio.Excluir(obj);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
                }
            };

        }

        private void Validar(DisponibilidadePeriodo sender, bool Exclusao = false)
        {
            if (sender == null)
                throw new Exception("Dados inválidos.");
            if (Exclusao)
                if ((sender?.Id ?? 0) == 0)
                throw new Exception("Id não informado.");
            if (!Exclusao)
                if ((sender?.Descricao ?? string.Empty).Length == 0)
                    throw new Exception("Descrição não informada.");
        }

        public override IEnumerable<DisponibilidadePeriodo> Listar(Expression<Func<DisponibilidadePeriodo, bool>> predicate = null)
        {
            return NucleoDados.DisponibilidadePeriodoRepositorio.Listar(predicate);
        }

        public override DisponibilidadePeriodo Recuperar(Expression<Func<DisponibilidadePeriodo, bool>> predicate)
        {
            return NucleoDados.DisponibilidadePeriodoRepositorio.Recuperar(predicate);
        }

    }
}
