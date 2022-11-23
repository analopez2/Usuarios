using Excepciones;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        public DbContextUsuarios Contexto { get; set; }

        public RepositorioUsuarios(DbContextUsuarios ctx)
        {
            Contexto = ctx;
        }
        public void Add(Usuario nuevo)
        {
            nuevo.Validar();
            Contexto.Add(nuevo);
            Contexto.SaveChanges();
           
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios.Include(u => u.UsuarioRol).ToList();
           
        }

        public Usuario FindById(int Id)
        {
            return Contexto.Usuarios.Where(u => u.Id==Id).SingleOrDefault();
        }
        public Usuario FindByEmail(string eMail)
        {
            return Contexto.Usuarios.Where(u => u.Email == eMail).SingleOrDefault();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
