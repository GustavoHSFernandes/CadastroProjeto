using DDD.Application.Service;
using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.Service;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisadorController : ControllerBase
    {
        readonly IPesquisadorRepository _pesquisadorRepository;
        readonly ApplicationServiceCadastroProjeto _cadastroService;

        public PesquisadorController(IPesquisadorRepository pesquisadorRepository, ApplicationServiceCadastroProjeto cadastroService)
        {
            _pesquisadorRepository = pesquisadorRepository;
            _cadastroService = cadastroService;
        }

        //GET : api/<PesquisadorController>
        [HttpGet]
        public ActionResult<List<Pesquisador>> Get()
        {
            return Ok(_pesquisadorRepository.GetPesquisadores());
        }

        [HttpGet("{id}")]
        public ActionResult<Pesquisador> GetById(int id)
        {
            return Ok(_pesquisadorRepository.GetPesquisadorById(id));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pesquisador> CreatePesquisador(Pesquisador pesquisador)
        {
            if (pesquisador.Nome.Length < 3 || pesquisador.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _pesquisadorRepository.InsertPesquisador(pesquisador);
            return CreatedAtAction(nameof(GetById), new { id = pesquisador.UserId }, pesquisador);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Pesquisador pesquisador)
        {
            try
            {
                if (pesquisador == null)
                    return NotFound();

                _pesquisadorRepository.UpdatePesquisador(pesquisador);
                return Ok("Pesquisador Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] Pesquisador pesquisador)
        {
            try
            {
                if (pesquisador == null)
                    return NotFound();

                _pesquisadorRepository.DeletePesquisador(pesquisador);
                return Ok("Pesquisador Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
