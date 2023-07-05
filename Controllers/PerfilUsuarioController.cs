using API_Financeira.DTO;
using API_Financeira.Exceptions;
using API_Financeira.Models;
using API_Financeira.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Financeira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilUsuarioController : ControllerBase
    {
        private readonly PerfilUsuarioService _perfilService;

        public PerfilUsuarioController(PerfilUsuarioService perfilService)
        {
            _perfilService = perfilService;
        }

        [HttpPost("CriarPerfil")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioDTO> CriarPerfil(PerfilUsuarioDTO perfilDTO)
        {
            try
            {
                UsuarioDTO usuarioRetorno = _perfilService.adicionarPerfil(perfilDTO);
                return CreatedAtRoute(nameof(buscarPerfil), new { id = usuarioRetorno.Id }, usuarioRetorno);
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

        [HttpGet("{id}", Name = nameof(buscarPerfil))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Usuario> buscarPerfil(string id)
        {
            return Ok();
        }
    }
}
