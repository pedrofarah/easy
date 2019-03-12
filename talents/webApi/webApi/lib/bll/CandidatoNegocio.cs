using lib.dto;
using lib.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace lib.bll
{
    public class CandidatoNegocio : Negocio<Candidato>
    {
        public CandidatoNegocio(INucleoDados _nucleoDados) : base(_nucleoDados)
        {
            NucleoDados = _nucleoDados;

            ValidacaoAdicionar += (sender) =>
            {
                try
                {
                    Validar(sender);

                    foreach (CandidatoLinguagem item in ((Candidato)sender).lstCandidatoLinguagem)
                    {
                        item.linguagem = null;
                    }

                    foreach (CandidatoDisponibilidadeHoras item in ((Candidato)sender).lstCandidatoDisponibilidadeHoras)
                    {
                        item.disponibilidadeHoras = null;
                    }

                    foreach (CandidatoDisponibilidadePeriodo item in ((Candidato)sender).lstCandidatoDisponibilidadePeriodo)
                    {
                        item.disponibilidadePeriodo = null;
                    }

                    NucleoDados.CandidatoRepositorio.Adicionar(sender);
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

                    foreach(CandidatoLinguagem item in ((Candidato)sender).lstCandidatoLinguagem)
                    {
                        item.candidato = (Candidato)sender;
                        item.linguagem = null;
                    }

                    foreach (CandidatoDisponibilidadeHoras item in ((Candidato)sender).lstCandidatoDisponibilidadeHoras)
                    {
                        item.candidato = (Candidato)sender;
                        item.disponibilidadeHoras = null;
                    }

                    foreach (CandidatoDisponibilidadePeriodo item in ((Candidato)sender).lstCandidatoDisponibilidadePeriodo)
                    {
                        item.candidato = (Candidato)sender;
                        item.disponibilidadePeriodo = null;
                    }

                    NucleoDados.CandidatoRepositorio.Atualizar(sender);
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

                    Candidato obj = NucleoDados.CandidatoRepositorio.Recuperar(p => p.Id == sender.Id) 
                        ?? throw new Exception("Registro não localizado. Impossível excluir.");

                    NucleoDados.CandidatoRepositorio.Excluir(obj);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
                }
            };
        }

        private void Validar(Candidato sender, bool Exclusao = false)
        {

            if (sender == null)
                throw new Exception("Dados inválidos.");

            if (Exclusao)
                if ((sender?.Id ?? 0) == 0)
                    throw new Exception("Id não informado.");

            if (!Exclusao)
            {
                if ((sender?.email ?? string.Empty).Length == 0)
                    throw new Exception("Email não informado.");
                if ((sender?.nome ?? string.Empty).Length == 0)
                    throw new Exception("Nome não informado.");
                if ((sender?.skype ?? string.Empty).Length == 0)
                    throw new Exception("Skype não informado.");
                if ((sender?.telefone ?? string.Empty).Length == 0)
                    throw new Exception("Telefone não informado.");
                if ((sender?.pretencao_salarial_hora ?? 0) == 0)
                    throw new Exception("Pretenção salarial não informada.");
                if ((sender?.cidade ?? string.Empty).Length == 0)
                    throw new Exception("Cidade não informada.");
                if ((sender?.uf ?? string.Empty).Length == 0)
                    throw new Exception("UF não informada.");
            }

        }

        public override IEnumerable<Candidato> Listar(Expression<Func<Candidato, bool>> predicate = null)
        {
            return NucleoDados.CandidatoRepositorio.Listar(predicate);
        }

        public override Candidato Recuperar(Expression<Func<Candidato, bool>> predicate)
        {
            return NucleoDados.CandidatoRepositorio.Recuperar(predicate);
        }

        public ListasRelacionamentos RetornarListagemRelacionamentos()
        {
            ListasRelacionamentos retorno = new ListasRelacionamentos
            {
                ListaDisponibilidadeHoras = NucleoDados.DisponibilidadeHorasRepositorio.Listar(r => r.Id > 0).OrderBy(r => r.Id).ToList(),
                ListaDisponibilidadePeriodo = NucleoDados.DisponibilidadePeriodoRepositorio.Listar(r => r.Id > 0).OrderBy(r => r.Id).ToList(),
                ListaLinguagem = NucleoDados.LinguagemRepositorio.Listar(r => r.Id > 0).OrderBy(r => r.Id).ToList()
            };

            return retorno;
        }

    }
}
