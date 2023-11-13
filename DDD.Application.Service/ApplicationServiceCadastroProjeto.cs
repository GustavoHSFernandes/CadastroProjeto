using DDD.Domain.SecretariaContext;
using DDD.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application.Service
{
    public class ApplicationServiceCadastroProjeto
    {
        readonly CadastroService _cadastroService;

        public ApplicationServiceCadastroProjeto(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public void GerarCadastro(int ProjetoId, int SecretariaId, int PesquisadorId)
        {
            var cadastroEfetuado = _cadastroService.GerarCadastro(ProjetoId, SecretariaId, PesquisadorId);
            if (cadastroEfetuado)
            {
                //Enviar Email
            }
        }
    }
}
