using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LogicaNegocio.Dominio
{
    public class Usuario : IValidable
    {
        public int Id { get; set; }
        public string Password { get; set; }    
        public string Email { get; set; }
        public IEnumerable<UsuarioRol> UsuarioRol{ get; set; }
        public void Validar()
        {
            ValidarEmail();
        }

        private void ValidarEmail()
        {
            if (!Regex.IsMatch(Email, "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$")) throw new Exception("ERROR SELECCION | El email debe ser una dirección válida");
        }
    }
}
