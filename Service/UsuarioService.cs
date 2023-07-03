using API_Financeira.DTO;
using API_Financeira.Models;
using AutoMapper;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System.Net.Http;

namespace API_Financeira.Service
{
    public class UsuarioService
    {
        FirestoreDb db = FirestoreDb.Create("investimentoFinanceiro");

        private readonly IMapper _mapper;

        public UsuarioService(IMapper mapper)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            });
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> adicionarUsuario(Usuario usuario)
        {
            Dictionary<string, object> user = new Dictionary<string, object>
            {
                {"Username", usuario.Username},
                {"Nome", usuario.Nome},
                {"Senha", usuario.Senha},
                {"Email", usuario.Email}
            };

            DocumentReference addDocRef = await db.Collection("User").AddAsync(user);
            DocumentSnapshot snapshot = await addDocRef.GetSnapshotAsync();
            Usuario UsusarioRetorno = snapshot.ConvertTo<Usuario>();
            UsuarioDTO userDto = _mapper.Map<Usuario, UsuarioDTO>(UsusarioRetorno);
            userDto.Id = snapshot.Id;
            return userDto;
        }
    }
}
