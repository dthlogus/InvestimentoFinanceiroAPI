

using API_Financeira.DTO;
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
        public async Task<ActionResult<UsuarioDTO>> Post(Usuario usuario)
        {
            return await _usuarioService.adicionarUsuario(usuario);
        }
    }
}
