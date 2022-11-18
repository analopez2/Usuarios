using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.BaseDatos
{
    public class DbContextUsuarios : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

         public DbContextUsuarios(DbContextOptions<DbContextUsuarios> opciones) : base(opciones)
        {

        }
    }
}
