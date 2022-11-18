using System;

namespace Excepciones
{
    public class UsuarioException:Exception
    {
        public UsuarioException() { }
        public UsuarioException(string mensaje) : base(mensaje) { }
        public UsuarioException(string mensaje, Exception inner) : base(mensaje, inner) { }
    }
}
