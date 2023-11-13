using DDD.Application.Service;
using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        readonly ISecretariaRepository _secretariaRepository;
        readonly ApplicationServiceCadastroProjeto _cadastroService;

        public SecretariaController(ISecretariaRepository secretariaRepository, ApplicationServiceCadastroProjeto cadastroService)
        {
            _secretariaRepository = secretariaRepository;
            _cadastroService = cadastroService;
        }

        //GET : api/<PesquisadorController>
        [HttpGet]
        public ActionResult<List<Secretaria>> Get()
        {
            return Ok(_secretariaRepository.GetSecretarios());
        }

        [HttpGet("{id}")]
        public ActionResult<Secretaria> GetById(int id)
        {
            return Ok(_secretariaRepository.GetSecretariosById(id));
        }

        [HttpPost]
        [Route("gerarCadastro")]
        public void EfetuarCadastroApplicationService(int ProjetoId, int SecretariaId, int PesquisadorId)
        {
            _cadastroService.GerarCadastro(ProjetoId, SecretariaId, PesquisadorId);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Secretaria> CreateSecretarios(Secretaria secretaria)
        {
            if (secretaria.Nome.Length < 3 || secretaria.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _secretariaRepository.InsertSecretario(secretaria);
            return CreatedAtAction(nameof(GetById), new { id = secretaria.UserId }, secretaria);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Secretaria secretaria)
        {
            try
            {
                if (secretaria == null)
                    return NotFound();

                _secretariaRepository.UpdateSecretario(secretaria);
                return Ok("Secretaria(o) Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] Secretaria secretaria)
        {
            try
            {
                if (secretaria == null)
                    return NotFound();

                _secretariaRepository.DeleteSecretario(secretaria);
                return Ok("Secretaria(o) Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
