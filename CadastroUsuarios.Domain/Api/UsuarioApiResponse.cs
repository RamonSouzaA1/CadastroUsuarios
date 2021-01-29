using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarios.Domain.Api
{
    public class UsuarioApiResponse<TModel> : UsuarioApiResponse
    {
        public TModel Data { get; set; }
    }

    public class UsuarioApiResponse
    {
        public UsuarioApiResponse()
        {
            this.Success = true;
            this.Message = null;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
