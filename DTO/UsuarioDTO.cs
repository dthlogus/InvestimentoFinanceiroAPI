namespace API_Financeira.DTO
{
    public class UsuarioDTO
    {
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public UsuarioDTO() { }

        public UsuarioDTO(string id, string nome, string email) { Id = id; Nome = nome; Email = email;}
    }
}
