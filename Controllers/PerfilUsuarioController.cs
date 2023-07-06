using API_Financeira.DTO;
using API_Financeira.Exceptions;
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

        [HttpPut("AtualizarPerfil")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioDTO> AtualizarPerfil(PerfilUsuarioDTO perfilDTO)
        {
            try
            {
                _perfilService.atualizarPerfil(perfilDTO);
                return Ok();
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
    }
}
