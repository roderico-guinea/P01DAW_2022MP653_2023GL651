using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2022MP653_2023GL651.Models;

namespace P01_2022MP653_2023GL651.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string correo, string contraseña)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo && u.Contraseña == contraseña);
            if (usuario == null)
                return Unauthorized("Credenciales inválidas");

            return Ok("Inicio de sesión exitoso");
        }
    }

}
