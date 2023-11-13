using DDD.Domain.PicContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.SecretariaContext
{
    public class Secretaria : User
    {
        public List<Cadastro>? Cadastros { get; set; }
    }
}
