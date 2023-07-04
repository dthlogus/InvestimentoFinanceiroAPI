

using API_Financeira.DTO;
using API_Financeira.Exceptions;
using API_Financeira.Models;
using API_Financeira.Service;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioDTO> Post(Usuario usuario)
        {
            try
            {
                UsuarioDTO usuarioRetorno = _usuarioService.adicionarUsuario(usuario);
                return new CreatedAtActionResult(nameof(Post), "Usuario" ,new { id =  usuarioRetorno.Id}, usuarioRetorno);
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
