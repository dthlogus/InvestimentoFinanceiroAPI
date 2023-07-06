using API_Financeira.DTO;
using API_Financeira.Models;
using AutoMapper;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace API_Financeira.Service
{
    public class PerfilUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly UsuarioService _usuarioService;

        public PerfilUsuarioService(IMapper mapper, UsuarioService usuario)
        {
            _mapper = mapper;
            _usuarioService = usuario;
        }

        IFirebaseConfig firebase = new FirebaseConfig()
        {
            AuthSecret = "amWJOt8ZgCLnmjHIBz72WHD4WV5xDt0pGXqUigfs",
            BasePath = "https://investimentofinanceiro-ab26f-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient? client;

        public UsuarioDTO atualizarPerfil(PerfilUsuarioDTO perfilDto)
        {
            try{
                client = new FirebaseClient(firebase);
                var usuarioEncontrado = client.Get(perfilDto.idUsuario);
                Usuario user = usuarioEncontrado.ResultAs<Usuario>();
                PerfilUsuario perfilMapeado = _mapper.Map<PerfilUsuarioDTO, PerfilUsuario>(perfilDto);
                user.Perfil = perfilMapeado;
                var usuarioAtualizado = client.Update(perfilDto.idUsuario, user);
                UsuarioDTO usuarioDTO = _mapper.Map<Usuario, UsuarioDTO>(usuarioAtualizado.ResultAs<Usuario>());
                usuarioDTO.Id = perfilDto.idUsuario;
                return usuarioDTO;
            }catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado \n " + ex.Message);
            }
        }
    }
}
