using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ISecretariaRepository
    {
        public List<Secretaria> GetSecretarios();
        public Secretaria GetSecretariosById(int id);
        public void InsertSecretario(Secretaria secretaria);
        public void UpdateSecretario(Secretaria secretaria);
        public void DeleteSecretario(Secretaria secretaria);
        public void PersistirCadastro(CadastroProjetoPersistence cadastroProjetoPersistence);
    }
}
