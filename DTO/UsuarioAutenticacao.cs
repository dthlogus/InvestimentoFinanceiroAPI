namespace API_Financeira.DTO
{
    public class UsuarioAutenticacao
    {
        public string Username { get; set; }
        public string Senha { get; set; }

        public UsuarioAutenticacao() { }

        public UsuarioAutenticacao(string username, string senha)
        {
            Username = username;
            Senha = senha;
        }
    }
}
