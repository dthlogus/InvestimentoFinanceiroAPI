using API_Financeira.DTO;
using API_Financeira.Exceptions;
using API_Financeira.Models;
using AutoMapper;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace API_Financeira.Service
{
    public class UsuarioService
    {


        private readonly IMapper _mapper;

        public UsuarioService(IMapper mapper)
        {
            _mapper = mapper;
        }

        IFirebaseConfig firebase = new FirebaseConfig()
        {
            AuthSecret = "amWJOt8ZgCLnmjHIBz72WHD4WV5xDt0pGXqUigfs",
            BasePath = "https://investimentofinanceiro-ab26f-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient? client;

        public UsuarioDTO adicionarUsuario(Usuario usuario)
        {
            try
            {
                client = new FirebaseClient(firebase);
                var userReturn = client.Get("ListaUsuario/" + usuario.Username);
                if (userReturn != null)
                {
                    throw new UsuarioJaExisteException("Esse usuário já existe, por favor, escolha outro");
                }
                var user = client.Set("ListaUsuario/" + usuario.Username, usuario);
                UsuarioDTO userDTO = _mapper.Map<Usuario, UsuarioDTO>(user.ResultAs<Usuario>());
                userDTO.Id = "ListaUsuario/" + usuario.Username;
                return userDTO;
            }catch (UsuarioJaExisteException ex) 
            {
                throw new UsuarioJaExisteException(ex.Message);
            }catch (Exception)
            {
                throw new Exception("Ocorreu um erro inesperado");
            }
        }
    }
}

