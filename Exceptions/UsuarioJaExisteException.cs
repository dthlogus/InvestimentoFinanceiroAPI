using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;


namespace API_Financeira.Exceptions
{
    public class UsuarioJaExisteException: Exception
    {
        public UsuarioJaExisteException() : base() { }
        public UsuarioJaExisteException(string message) : base(message) { }
    }
}
