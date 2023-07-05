

using API_Financeira.DTO;
using API_Financeira.Exceptions;
using API_Financeira.Models;
using API_Financeira.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Financeira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UserController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("AutenticarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult AutenticarUsuario(UsuarioAutenticacao usuario)
        {
            try
            {
                bool usuarioRetorno = _usuarioService.autenticarUsuario(usuario);
                if (usuarioRetorno)
                {
                    return new OkResult();
                }
                else
                {
                    return new NotFoundObjectResult("Usuário não encontrado ou senha inválida.");
                }
            }
            catch (UsuarioJaExisteException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost("CriarUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioDTO> CriarUsuario(Usuario usuario)
        {
            try
            {
                UsuarioDTO usuarioRetorno = _usuarioService.adicionarUsuario(usuario);
                return CreatedAtRoute(nameof(buscarUsuario), new { id = usuarioRetorno.Id }, usuarioRetorno);
            }
            catch (UsuarioJaExisteException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("{id}", Name = nameof(buscarUsuario))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsuarioDTO> buscarUsuario(string id)
        {
            try
            {
                UsuarioDTO usuarioDTO = _usuarioService.buscarUsuario(id);
                if (usuarioDTO == null)
                {
                    return new NotFoundObjectResult("Usuário não encontrado");
                }
                return usuarioDTO;
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Ocorreu um erro inesperado. \n" + ex.Message);
            }
        }
    }
}
