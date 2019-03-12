using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using lib.bll;
using lib.dto;
using lib.interfaces;
using System.Linq;

namespace UnitTestWebApi
{

    [TestClass]
    public class UnitTestCandidato
    {

        public Candidato novoCandidato()
        {
            Candidato candidato = new Candidato
            {
                Id = 0,
                email = "candidato.teste@teste.net",
                nome = "Candidato Teste",
                telefone = "31989526752",
                skype = "candidato.skype@teste.net",
                cidade = "Vespasiano",
                uf = "Minas Gerais",
                pretencao_salarial_hora = 50,
                linkedin = "linkedin.candidato",
                link_crud = "crudteste.net",
                nota_outros = "Side Kick. Nota 1.",
                portifolio = "",
                lstCandidatoDisponibilidadeHoras = new List<CandidatoDisponibilidadeHoras> {
                    new CandidatoDisponibilidadeHoras { CandidatoId = 0, DisponibilidadeHorasId = 3 },
                    new CandidatoDisponibilidadeHoras { CandidatoId = 0, DisponibilidadeHorasId = 4 }
                },
                lstCandidatoDisponibilidadePeriodo = new List<CandidatoDisponibilidadePeriodo>
                {
                    new CandidatoDisponibilidadePeriodo { CandidatoId = 0, DisponibilidadePeriodoId = 1 },
                    new CandidatoDisponibilidadePeriodo { CandidatoId = 0, DisponibilidadePeriodoId = 2 },
                    new CandidatoDisponibilidadePeriodo { CandidatoId = 0, DisponibilidadePeriodoId = 3 }
                },
                lstCandidatoLinguagem = new List<CandidatoLinguagem>
                {
                    new CandidatoLinguagem { CandidatoId = 0, LinguagemId = 1, Nota = 5 },
                    new CandidatoLinguagem { CandidatoId = 0, LinguagemId = 2, Nota = 2 },
                    new CandidatoLinguagem { CandidatoId = 0, LinguagemId = 3, Nota = 4 }
                }
            };

            return candidato;

        }

        [TestMethod]
        public void Incluir()
        {
            Candidato obj_inc = novoCandidato();

            INegocio<Candidato> _Negocio = new CandidatoNegocio(DBContextPadrao.nucleoDados());

            _Negocio.Adicionar(obj_inc);

            Candidato _retorno_inc = _Negocio.Recuperar(p => p.nome == obj_inc.nome);

            Assert.AreEqual(obj_inc.Id, _retorno_inc.Id, "Falha na inclusão. Objeto de inclusão não localizado.");

        }

        [TestMethod]
        public void Editar()
        {
            Candidato obj_inc = novoCandidato();

            INegocio<Candidato> _Negocio = new CandidatoNegocio(DBContextPadrao.nucleoDados());

            _Negocio.Adicionar(obj_inc);

            Candidato _retorno_inc = _Negocio.Recuperar(p => p.nome == obj_inc.nome);

            _retorno_inc.nome = $"Teste edição {_retorno_inc.Id}";

            _Negocio.Atualizar(_retorno_inc);

            Candidato _retorno_alt = _Negocio.Recuperar(p => p.nome == _retorno_inc.nome);

            Assert.AreEqual(_retorno_alt.Id, _retorno_inc.Id, "Falha na edição. Objeto de edição não localizado.");
        }

        [TestMethod]
        public void Excluir()
        {
            Candidato obj_inc = novoCandidato();

            INegocio<Candidato> _Negocio = new CandidatoNegocio(DBContextPadrao.nucleoDados());

            _Negocio.Adicionar(obj_inc);

            Candidato _retorno_exc = _Negocio.Recuperar(p => p.nome == obj_inc.nome);

            _Negocio.Excluir(_retorno_exc);

            Candidato _retorno = _Negocio.Recuperar(p => p.Id == _retorno_exc.Id);

            Assert.IsNull(_retorno, "Falha na exclusão. Operação de exclusão não foi concluída com exito.");
        }

        [TestMethod]
        public void Listar()
        {
            INegocio<Candidato> _Negocio = new CandidatoNegocio(DBContextPadrao.nucleoDados());

            IEnumerable<Candidato> _lst_retorno_exc = _Negocio.Listar(p => p.Id > 0) ?? new List<Candidato>();

            foreach (Candidato item in _lst_retorno_exc)
            {
                _Negocio.Excluir(item);
            }            

            for (int x = 1; x <= 12; x++)
            {
                Candidato _novoCandidato = novoCandidato();
                _novoCandidato.nome += $" {x}";
                _Negocio.Adicionar(_novoCandidato);
            }

            IEnumerable<Candidato> _retorno = _Negocio.Listar(p => p.Id > 0);

            int esperado = 12;

            int retornado = _retorno?.Count() ?? 0;

            Assert.AreEqual(esperado, retornado, "Falha na listagem de registros.");
        }

    }

}
