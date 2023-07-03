using API_Financeira.Interface;
using Google.Cloud.Firestore;

namespace API_Financeira.Models
{
    [FirestoreData]
    public class User: IFirebaseEntity
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string Usuario { get; set; }
        [FirestoreProperty]
        public string Nome { get; set; }
        [FirestoreProperty]
        public string Senha { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }

        public User() 
        {
        
        }

        public User(string id, string usuario, string nome, string senha, string email)
        {
            Id = id;
            Usuario = usuario;
            Nome = nome;
            Senha = senha;
            Email = email;
        }   
    }
}
