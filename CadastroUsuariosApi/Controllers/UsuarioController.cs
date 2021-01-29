using CadastroUsuarios.Domain;
using CadastroUsuarios.Domain.Api;
using CadastroUsuarios.Repositorio;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace CadastroUsuariosApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IRepositorio<Usuario> _repositorioUsuario = new UsuarioRepositorio();

        [Route("api/Usuario/AdicionarUsuario")]
        [HttpPost]
        public IHttpActionResult AdicionarUsuario([FromBody]Usuario usuario)
        {
            var response = new UsuarioApiResponse();
            try
            {
                this._repositorioUsuario.Adicionar(usuario);
                return Ok(response);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }

        [Route("api/Usuario/ListarUsuarios")]
        [HttpGet]
        public IHttpActionResult ListarUsuarios()
        {
            var response = new UsuarioApiResponse<List<Usuario>>();
            try
            {
                response.Data = this._repositorioUsuario.Listar();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }

        [Route("api/Usuario/AlterarUsuario")]
        [HttpPost]
        public IHttpActionResult AlterarUsuario([FromBody] Usuario usuario)
        {
            var response = new UsuarioApiResponse();
            try
            {
                if (this._repositorioUsuario.GetById(usuario.Id) != null)
                {
                    this._repositorioUsuario.Alterar(usuario);
                    return Ok(response);
                } else
                {
                    response.Success = false;
                    return Content(HttpStatusCode.NotFound, response);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }

        [Route("api/Usuario/ExcluirUsuario")]
        [HttpGet]
        public IHttpActionResult ExcluirUsuario([FromUri] int id)
        {
            var response = new UsuarioApiResponse();
            try
            {
                if (this._repositorioUsuario.GetById(id) != null)
                {
                    this._repositorioUsuario.Excluir(id);
                    return Ok(response);
                } else
                {
                    response.Success = false;
                    return Content(HttpStatusCode.NotFound, response);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }
    }
}