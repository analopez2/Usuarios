using Excepciones;
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
            ValidarPassword(Password);
        }

        private void ValidarEmail()
        {
            if (!Regex.IsMatch(Email, "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$")) throw new UsuarioException("El email debe ser una dirección válida");
        }
        private void ValidarPassword(string password)
        {

            int numeros = 0;
            int mayusculas = 0;
            int minusculas = 0;
            int otros = 0;
            int invalidos = 0;
            foreach (char item in password)
            {
              
                if (char.IsNumber(item))
                {
                    numeros++;
                }
                else
                {
                    if (char.IsUpper(item))
                    {
                        mayusculas++;
                    }
                    else
                    {
                        if (char.IsLower(item))
                        {
                            minusculas++;
                        }
                        else
                        {
                            if (char.ToString(item) == "." || char.ToString(item) == "," || char.ToString(item) == "!")
                            {
                                otros++;
                            }
                            else
                            {
                                invalidos++;
                            }
                        }

                    }
                }
            }
            if (numeros == 0 || mayusculas == 0 || minusculas == 0 || otros != 1 || invalidos > 0 || password.Length < 8)
            {
                throw new UsuarioException("El password debe contener al menos 8 caracteres y debe contener una letra mayuscula, una letra minusula, un numero y un punto (.) o una coma (,) o un signo de cierre de exclamacion (!)");
            }
        }
           
    }
}
