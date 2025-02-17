using Microsoft.AspNetCore.Mvc;
using CoWorking.Repositories;
using CoWorking.Service;
using Models;

namespace CoWorking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private static List<Usuarios> usuarios = new List<Usuarios>();

        private readonly IUsuariosService _serviceUsuarios;

        public UsuariosController(IUsuariosService service)
        {
            _serviceUsuarios = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> GetUsuarios()
        {
            var usuarios = await _serviceUsuarios.GetAllAsync();
            return Ok(usuarios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuario(int id)
        {
            var usuario = await _serviceUsuarios.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }


        [HttpPost]
        public async Task<ActionResult<Usuarios>> CreateUsuario(Usuarios usuarios)
        {
            await _serviceUsuarios.AddAsync(usuarios);
            return CreatedAtAction(nameof(CreateUsuario), new { id = usuarios.IdUsuario }, usuarios);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuarios updatedUsuarios)
        {
            var existingUsuario = await _serviceUsuarios.GetByIdAsync(id);
            if (existingUsuario == null)
            {
                return NotFound();
            }
            existingUsuario.Nombre = updatedUsuarios.Nombre;
            existingUsuario.Apellidos = updatedUsuarios.Apellidos;
            existingUsuario.DNI = updatedUsuarios.DNI;
            existingUsuario.Email = updatedUsuarios.Email;
            existingUsuario.Contrasenia = updatedUsuarios.Contrasenia;
            existingUsuario.Telefono = updatedUsuarios.Telefono;
            existingUsuario.FechaRegistro = updatedUsuarios.FechaRegistro;
            existingUsuario.IdRol = updatedUsuarios.IdRol;


            await _serviceUsuarios.UpdateAsync(existingUsuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _serviceUsuarios.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            await _serviceUsuarios.DeleteAsync(id);
            return NoContent();



        }
    }
}