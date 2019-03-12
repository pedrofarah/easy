using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using lib.bll;
using lib.dto;
using lib.interfaces;
using System.Linq;

namespace UnitTestWebApi
{
    [TestClass]
    public class UnitTestLinguagem
    {

        [TestMethod]
        public void Incluir()
        {
            Linguagem obj_inc = new Linguagem { Id = 0, Nome = "Teste inclusão" };

            INegocio<Linguagem> _Negocio = new LinguagemNegocio(DBContextPadrao.nucleoDados());

            _Negocio.Adicionar(obj_inc);

            Linguagem _retorno_inc = _Negocio.Recuperar(p => p.Nome == obj_inc.Nome);

            Assert.AreEqual(obj_inc.Id, _retorno_inc.Id, "Falha na inclusão. Objeto de inclusão não localizado.");

        }

        [TestMethod]
        public void Editar()
        {
            Linguagem obj_inc = new Linguagem { Id = 0, Nome = "Teste edição" };

            INegocio<Linguagem> _Negocio = new LinguagemNegocio(DBContextPadrao.nucleoDados());

            _Negocio.Adicionar(obj_inc);

            Linguagem _retorno_inc = _Negocio.Recuperar(p => p.Nome == obj_inc.Nome);

            _retorno_inc.Nome = $"Teste edição {_retorno_inc.Id}";

            _Negocio.Atualizar(_retorno_inc);

            Linguagem _retorno_alt = _Negocio.Recuperar(p => p.Nome == _retorno_inc.Nome);

            Assert.AreEqual(_retorno_alt.Id, _retorno_inc.Id, "Falha na edição. Objeto de edição não localizado.");
        }

        [TestMethod]
        public void Excluir()
        {
            Linguagem obj_inc = new Linguagem { Id = 99, Nome = "Teste inclusão" };

            INegocio<Linguagem> _Negocio = new LinguagemNegocio(DBContextPadrao.nucleoDados());

            _Negocio.Adicionar(obj_inc);

            Linguagem _retorno_exc = _Negocio.Recuperar(p => p.Nome == obj_inc.Nome);

            _Negocio.Excluir(_retorno_exc);

            Linguagem _retorno = _Negocio.Recuperar(p => p.Id == _retorno_exc.Id);

            Assert.IsNull(_retorno, "Falha na exclusão. Operação de exclusão não foi concluída com exito.");

        }

        [TestMethod]
        public void Listar()
        {

            INegocio<Linguagem> _Negocio = new LinguagemNegocio(DBContextPadrao.nucleoDados());

            IEnumerable<Linguagem> _lst_retorno_exc = _Negocio.Listar(p => p.Id > 0) ?? new List<Linguagem>();

            foreach (Linguagem item in _lst_retorno_exc)
            {
                _Negocio.Excluir(item);
            }            

            for (int x = 1; x <= 12; x++)
            {
                _Negocio.Adicionar(new Linguagem { Id = 0, Nome = $"Registro {x}" });
            }

            IEnumerable<Linguagem> _retorno = _Negocio.Listar(p => p.Id > 0);

            int esperado = 12;

            int retornado = _retorno?.Count() ?? 0;

            Assert.AreEqual(esperado, retornado, "Falha na listagem de registros.");

        }

    }
}
