using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using lib.bll;
using lib.dto;
using lib.interfaces;
using System.Linq;

namespace UnitTestWebApi
{
    [TestClass]
    public class UnitTestDisponibilidadeHoras
    {

        [TestMethod]
        public void Incluir()
        {
            DisponibilidadeHoras obj_inc = new DisponibilidadeHoras { Id = 0, Descricao = "Teste inclusão" };

            INegocio<DisponibilidadeHoras> _Negocio = new DisponibilidadeHorasNegocio(DBContextPadrao.nucleoDados());

            _Negocio.Adicionar(obj_inc);

            DisponibilidadeHoras _retorno_inc = _Negocio.Recuperar(p => p.Descricao == obj_inc.Descricao);

            Assert.AreEqual(obj_inc.Id, _retorno_inc.Id, "Falha na inclusão. Objeto de inclusão não localizado.");

        }

        [TestMethod]
        public void Editar()
        {
            DisponibilidadeHoras obj_inc = new DisponibilidadeHoras { Id = 0, Descricao = "Teste edição" };

            INegocio<DisponibilidadeHoras> _Negocio = new DisponibilidadeHorasNegocio(DBContextPadrao.nucleoDados());

            _Negocio.Adicionar(obj_inc);

            DisponibilidadeHoras _retorno_inc = _Negocio.Recuperar(p => p.Descricao == obj_inc.Descricao);

            _retorno_inc.Descricao = $"Teste edição {_retorno_inc.Id}";

            _Negocio.Atualizar(_retorno_inc);

            DisponibilidadeHoras _retorno_alt = _Negocio.Recuperar(p => p.Descricao == _retorno_inc.Descricao);

            Assert.AreEqual(_retorno_alt.Id, _retorno_inc.Id, "Falha na edição. Objeto de edição não localizado.");
        }

        [TestMethod]
        public void Excluir()
        {
            DisponibilidadeHoras obj_inc = new DisponibilidadeHoras { Id = 99, Descricao = "Teste inclusão" };

            INegocio<DisponibilidadeHoras> _Negocio = new DisponibilidadeHorasNegocio(DBContextPadrao.nucleoDados());

            _Negocio.Adicionar(obj_inc);

            DisponibilidadeHoras _retorno_exc = _Negocio.Recuperar(p => p.Descricao == obj_inc.Descricao);

            _Negocio.Excluir(_retorno_exc);

            DisponibilidadeHoras _retorno = _Negocio.Recuperar(p => p.Id == _retorno_exc.Id);

            Assert.IsNull(_retorno, "Falha na exclusão. Operação de exclusão não foi concluída com exito.");
        }

        [TestMethod]
        public void Listar()
        {

            INegocio<DisponibilidadeHoras> _Negocio = new DisponibilidadeHorasNegocio(DBContextPadrao.nucleoDados());

            IEnumerable<DisponibilidadeHoras> _lst_retorno_exc = _Negocio.Listar(p => p.Id > 0) ?? new List<DisponibilidadeHoras>();

            foreach (DisponibilidadeHoras item in _lst_retorno_exc)
            {
                _Negocio.Excluir(item);
            }            

            for (int x = 1; x <= 12; x++)
            {
                _Negocio.Adicionar(new DisponibilidadeHoras { Id = 0, Descricao = $"Registro {x}" });
            }

            IEnumerable<DisponibilidadeHoras> _retorno = _Negocio.Listar(p => p.Id > 0);

            int esperado = 12;

            int retornado = _retorno?.Count() ?? 0;

            Assert.AreEqual(esperado, retornado, "Falha na listagem de registros.");

        }

    }
}
