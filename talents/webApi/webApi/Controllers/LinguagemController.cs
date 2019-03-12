using Microsoft.AspNetCore.Mvc;
using lib.dto;
using lib.interfaces;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinguagemController : AppBaseCrudController<Linguagem>
    {
        public LinguagemController(INegocio<Linguagem> negocio) : base(negocio)
        {
            Negocio = negocio;

            RecuperarAction += (obj) => Negocio.Recuperar(l => l.Id == (long)obj);

            ExcluirAction += (obj) => Negocio.Excluir(new Linguagem { Id = (long)obj });
        }

    }

}
