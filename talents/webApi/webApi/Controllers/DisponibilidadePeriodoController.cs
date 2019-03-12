using lib.dto;
using lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadePeriodoController : AppBaseCrudController<DisponibilidadePeriodo>
    {

        public DisponibilidadePeriodoController(INegocio<DisponibilidadePeriodo> negocio) : base(negocio)
        {
            Negocio = negocio;

            RecuperarAction += (obj) => Negocio.Recuperar(l => l.Id == (long)obj);

            ExcluirAction += (obj) => Negocio.Excluir(new DisponibilidadePeriodo { Id = (long)obj });
        }

    }

}
