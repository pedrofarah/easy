using System;
using System.Collections.Generic;
using lib.interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{

    public delegate object ActionRecuperar(object valor);

    public delegate void ActionExcluir(object valor);

    [Route("api/[controller]")]
    public class AppBaseCrudController<T> : Controller where T : class 
    {

        public INegocio<T> Negocio { get; set; }

        public AppBaseCrudController(INegocio<T> negocio)
        {
            Negocio = negocio;
        }

        public event ActionRecuperar RecuperarAction;

        public event ActionExcluir ExcluirAction;

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return Negocio.Listar();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public T Get(long id)
        {
            return (T)RecuperarAction.Invoke(id);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]T value)
        {
            try
            {
                Negocio.Adicionar(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.Message ?? ex.Message);
            }

            return Ok();

        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]T value)
        {
            try
            {
                Negocio.Atualizar(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.Message ?? ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                ExcluirAction?.Invoke(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.Message ?? ex.Message);
            }

            return Ok();
        }

    }
}
