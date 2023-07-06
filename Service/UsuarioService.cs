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
                if (userReturn.Body != "null")
                {
                    throw new UsuarioJaExisteException("Esse usuário já existe, por favor, escolha outro");
                }
                string senhaCriptografada = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                usuario.Senha = senhaCriptografada;
                usuario = criarPerfilVazio(usuario);
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

        public bool autenticarUsuario(UsuarioAutenticacao usuario)
        {
            try { 
            client = new FirebaseClient(firebase);
            var userReturn = client.Get("ListaUsuario/" + usuario.Username);
            if (userReturn == null)
            {
                return false;
            }

            bool match = BCrypt.Net.BCrypt.Verify(usuario.Senha, userReturn.ResultAs<Usuario>().Senha);
            return match;

            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public Usuario buscarUsuario(string id)
        {
            try
            {
                client = new FirebaseClient(firebase);
                var userReturn = client.Get(id);
                if (userReturn.Body == "null")
                {
                    return null;
                }
                Usuario usuario = userReturn.ResultAs<Usuario>();
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool atualizarUsuario(Usuario usuario)
        {
            try
            {
                client = new FirebaseClient(firebase);
                var usuarioEncontrado = client.Get("ListaUsuario/" + usuario.Username);
                if (usuarioEncontrado.Body == "null")
                {
                    return false;
                }
                string senhaCriptografada = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                usuario.Senha = senhaCriptografada;
                var usuarioRetorno = client.Update("ListaUsuario/" + usuario.Username, usuario);
                return true;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Usuario criarPerfilVazio(Usuario usuario)
        {
            usuario.Perfil.pv = 0;
            usuario.Perfil.pvp = 0;
            usuario.Perfil.vpa = 0;
            usuario.Perfil.lpa = 0;
            usuario.Perfil.dy = 0;
            usuario.Perfil.simbolos = "";
            return usuario;
        }
    }
}

