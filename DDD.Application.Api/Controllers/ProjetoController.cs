using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        readonly IProjetoRepository _projetoRepository;
        
        public ProjetoController(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public ActionResult<List<Projeto>> Get()
        {
            return Ok(_projetoRepository.GetProjeto());
        }

        [HttpGet("{id}")]
        public ActionResult<Projeto> GetById(int id)
        {
            return Ok(_projetoRepository.GetProjetosById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Projeto> CreateProjeto(Projeto projeto)
        {
            _projetoRepository.InsertProjeto(projeto);
            return CreatedAtAction(nameof(GetById), new { id = projeto.ProjetoId }, projeto);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Projeto projeto)
        {
            try
            {
                if (projeto == null)
                    return NotFound();

                _projetoRepository.UpdateProjeto(projeto);
                return Ok("Projeto Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Projeto projeto)
        {
            try
            {
                if (projeto == null)
                    return NotFound();

                _projetoRepository.DeleteProjeto(projeto);
                return Ok("Projeto Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
