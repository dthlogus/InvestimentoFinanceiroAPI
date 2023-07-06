namespace API_Financeira.DTO
{
    public class PerfilUsuarioDTO
    {
        public string idUsuario { get; set; }
        public double? pv { get; set; }
        public double? pvp { get; set; }
        public double? dy { get; set; }
        public double? lpa { get; set; }
        public double? vpa { get; set; }
        public string? simbolos { get; set; }
    }
}
