using DDD.Application.Service;

namespace DDD.Application.Api.Controllers
{
    public class CadastroController
    {
        readonly ApplicationServiceCadastroProjeto _cadastroService;

        public CadastroController(ApplicationServiceCadastroProjeto cadastroService)
        {
            _cadastroService = cadastroService;
        }




    }
}
