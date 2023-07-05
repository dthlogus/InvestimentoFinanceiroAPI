

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
    public class UserController
    {
        private readonly UsuarioService _usuarioService;

        public UserController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("autenticarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AutenticarUsuario(UsuarioAutenticacao usuario)
        {
            try
            {
                Boolean usuarioRetorno = _usuarioService.buscarUsuario(usuario);
                if (usuarioRetorno)
                {
                    return new OkResult();
                }
                else
                {
                    return new NotFoundObjectResult("Usuário não encontrado ou senha inválida.");
                }
            }catch (UsuarioJaExisteException ex) {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex) 
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost("criarUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioDTO> CriarUsuario(Usuario usuario)
        {
            try
            {
                UsuarioDTO usuarioRetorno = _usuarioService.adicionarUsuario(usuario);
                return new CreatedAtActionResult(nameof(CriarUsuario), "Usuario" ,new { id =  usuarioRetorno.Id}, usuarioRetorno);
            }catch (UsuarioJaExisteException ex) 
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
