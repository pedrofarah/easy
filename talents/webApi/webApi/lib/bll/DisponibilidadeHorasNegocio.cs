using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using lib.dto;
using lib.interfaces;

namespace lib.bll
{
    public class DisponibilidadeHorasNegocio : Negocio<DisponibilidadeHoras>
    {

        public DisponibilidadeHorasNegocio(INucleoDados _nucleoDados) : base(_nucleoDados)
        {
            NucleoDados = _nucleoDados;

            ValidacaoAdicionar += (sender) =>
            {
                try
                {
                    Validar(sender);
                    NucleoDados.DisponibilidadeHorasRepositorio.Adicionar(sender);
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
                    NucleoDados.DisponibilidadeHorasRepositorio.Atualizar(sender);
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

                    DisponibilidadeHoras obj = NucleoDados.DisponibilidadeHorasRepositorio.Recuperar(p => p.Id == sender.Id)
                        ?? throw new Exception("Registro não localizado. Impossível excluir.");

                    NucleoDados.DisponibilidadeHorasRepositorio.Excluir(obj);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
                }
            };
        }

        private void Validar(DisponibilidadeHoras sender, bool Exclusao = false)
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

        public override IEnumerable<DisponibilidadeHoras> Listar(Expression<Func<DisponibilidadeHoras, bool>> predicate = null)
        {
            return NucleoDados.DisponibilidadeHorasRepositorio.Listar(predicate);
        }

        public override DisponibilidadeHoras Recuperar(Expression<Func<DisponibilidadeHoras, bool>> predicate)
        {
            return NucleoDados.DisponibilidadeHorasRepositorio.Recuperar(predicate);
        }

    }
}
