using API_Financeira.DTO;
using API_Financeira.Models;
using AutoMapper;
using FirebaseAdmin;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System.Net.Http;

namespace API_Financeira.Service
{
    public class UsuarioService
    {


        private readonly IMapper _mapper;

        public UsuarioService(IMapper mapper)
        {
            string appName = "InvestimentoFinanceiro";



            _mapper = mapper;
        }

        IFirebaseConfig firebase = new FirebaseConfig()
        {
            AuthSecret = "amWJOt8ZgCLnmjHIBz72WHD4WV5xDt0pGXqUigfs",
            BasePath = "https://investimentofinanceiro-ab26f-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        public async Task<UsuarioDTO> adicionarUsuario(Usuario usuario)
        {
            try
            {
                client = new FirebaseClient(firebase);
                var user = client.Set("ListaUsuario/" + usuario.Username, usuario);
                UsuarioDTO userDTO = _mapper.Map<Usuario, UsuarioDTO>(user.ResultAs<Usuario>());
                userDTO.Id = "ListaUsuario/" + usuario.Username;
                return userDTO;
            }catch (Exception ex)
            {
                throw;
            }
        }
    }
}

