namespace API_Financeira.Models
{
    public class PerfilUsuario
    {
        public double pv { get; set; }
        public double pvp { get; set; }
        public double dy { get; set; }
        public double lpa { get; set; }
        public double vpa { get; set; }
        public string simbolos { get; set; }

        public PerfilUsuario() { }

        public PerfilUsuario(double pv, double pvp, double dy, double lpa, double vpa, string simbolos, string idUsuario)
        {
            this.pv = pv;
            this.pvp = pvp;
            this.dy = dy;
            this.lpa = lpa;
            this.vpa = vpa;
            this.simbolos = simbolos;
        }
    }
}
