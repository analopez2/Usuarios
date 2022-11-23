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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.Email).IsUnique(true);

            modelBuilder.Entity<UsuarioRol>().HasKey(ur=> new { ur.RolId, ur.UsuarioId });

           
            base.OnModelCreating(modelBuilder);
        }
    }
}
