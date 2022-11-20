using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excepciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }

        public UsuariosController(IRepositorioUsuarios repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Usuario> usuarios = RepoUsuarios.FindAll();
            if (usuarios.Count() == 0) return NotFound();
            return Ok(usuarios);
           
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                Usuario buscado = RepoUsuarios.FindById(id);
                if (buscado == null) return NotFound();
                return Ok(buscado);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                List<UsuarioRol> usuarioRoles = new List<UsuarioRol>();
                UsuarioRol ur = new UsuarioRol();
                ur.RolId = 3;
                usuarioRoles.Add(ur);
                usuario.UsuarioRol = usuarioRoles;
                if (usuario == null) return BadRequest("Body vacío");               
                RepoUsuarios.Add(usuario);
                return Created("api/Usuarios/" + usuario.Id, usuario);
            }
            catch (UsuarioException e)
            {
                return BadRequest(e.Message); ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
