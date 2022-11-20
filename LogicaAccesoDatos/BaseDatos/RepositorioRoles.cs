using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioRoles : IRepositorioRoles
    {
        public DbContextUsuarios Contexto { get; set; }

        public RepositorioRoles(DbContextUsuarios ctx)
        {
            Contexto = ctx;
        }
        public void Add(Rol obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> FindAll()
        {
            return Contexto.Roles.ToList();
        }

        public Rol FindById(int Id)
        {
            return Contexto.Roles.Where(r => r.Id == Id).SingleOrDefault();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol obj)
        {
            throw new NotImplementedException();
        }
    }
}
