using DDD.Domain.PicContext;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Service
{
    public class CadastroService
    {
        readonly IProjetoRepository _projetoRepository;
        readonly ISecretariaRepository _secretariaRepository;
        readonly IPesquisadorRepository _pesquisadorRepository;

        public CadastroService(IProjetoRepository projetoRepository, ISecretariaRepository secretariaRepository, IPesquisadorRepository pesquisadorRepository)
        {
            _projetoRepository = projetoRepository;
            _secretariaRepository = secretariaRepository;
            _pesquisadorRepository = pesquisadorRepository;
        }



        public bool GerarCadastro(int ProjetoId, int SecretariaId, int PesquisadorId)
        {
            try
            {
                Cadastro cadastro = new Cadastro();
                var projeto = _projetoRepository.GetProjetosById(ProjetoId);
                var secretaria = _secretariaRepository.GetSecretariosById(SecretariaId);
                var pesquisador = _pesquisadorRepository.GetPesquisadorById(PesquisadorId);

                CadastroProjetoPersistence cadastroPersistence = new CadastroProjetoPersistence();

                if (projeto.AnosDuracao >= 1 & pesquisador.Titulacao == Enums.TitulacaoType.Mestre  & projeto.Setor == Enums.ProjectSectorType.PosGraduacao)
                {
                    cadastroPersistence.ProjetoId = ProjetoId;
                    cadastroPersistence.PesquisadorId = PesquisadorId;
                }
                _secretariaRepository.PersistirCadastro(cadastroPersistence);
                
                return true;

            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }
        }
    }
}
