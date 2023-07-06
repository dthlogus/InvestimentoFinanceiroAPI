using Google.Cloud.Firestore;

namespace API_Financeira.Models
{
    [FirestoreData]
    public class Usuario
    {
        [FirestoreProperty]
        public string Username { get; set; }
        [FirestoreProperty]
        public string Nome { get; set; }
        [FirestoreProperty]
        public string Senha { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public PerfilUsuario Perfil { get; set; }
    }
}
