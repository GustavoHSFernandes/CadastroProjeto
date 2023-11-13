using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class SecretariaRepositorySqlServer : ISecretariaRepository
    {
        private readonly SqlContext _context;

        public SecretariaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteSecretario(Secretaria secretaria)
        {
            try
            {
                _context.Set<Secretaria>().Remove(secretaria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Secretaria GetSecretariosById(int id)
        {
            return _context.Secretarios.Find(id);
        }

        public List<Secretaria> GetSecretarios()
        {
            //return  _context.Alunos.Include(x => x.Disciplinas).ToList();
            return _context.Secretarios.ToList();

        }

        public void InsertSecretario(Secretaria secretaria)
        {
            try
            {
                _context.Secretarios.Add(secretaria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void PersistirCadastro(CadastroProjetoPersistence cadastroProjetoPersistence)
        {
            try
            {
                _context.Cadastros.Add(cadastroProjetoPersistence);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateSecretario(Secretaria secretaria)
        {
            try
            {
                _context.Entry(secretaria).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
