using lib.bll;
using lib.dto;
using lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    public class CandidatoController : AppBaseCrudController<Candidato>
    {

        public CandidatoController(INegocio<Candidato> negocio) : base(negocio)
        {
            Negocio = negocio;

            RecuperarAction += (obj) => Negocio.Recuperar(l => l.Id == (long)obj);

            ExcluirAction += (obj) => Negocio.Excluir(new Candidato { Id = (long)obj });

        }

        [HttpGet("Listas")]
        public ListasRelacionamentos Listas()
        {
            return ((CandidatoNegocio)Negocio).RetornarListagemRelacionamentos();
        }



    }

}
