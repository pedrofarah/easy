using System.Collections.Generic;
using System.Linq;
using lib.bll;
using lib.dto;
using lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadeHorasController : AppBaseCrudController<DisponibilidadeHoras>
    {

        public DisponibilidadeHorasController(INegocio<DisponibilidadeHoras> negocio) : base(negocio)
        {
            Negocio = negocio;

            RecuperarAction += (obj) => Negocio.Recuperar(l => l.Id == (long)obj);

            ExcluirAction += (obj) => Negocio.Excluir(new DisponibilidadeHoras { Id = (long)obj });
        }

    }

}
