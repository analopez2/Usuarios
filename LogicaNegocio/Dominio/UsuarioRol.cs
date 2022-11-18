using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
     public class UsuarioRol
    {
        public Usuario Usuario { get; set; }
        public Rol Rol { get; set; }

        public int UsuarioId { get; set; }

        public int RolId { get; set; }

    }
}
