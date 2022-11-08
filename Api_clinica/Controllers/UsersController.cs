using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_clinica.Context;
using Api_clinica.Models;

namespace Api_clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Getusuarios()
        {
            return await _context.users.ToListAsync();
        }

        // GET: api/Usuarios/5
      
        

        [HttpGet("{username}/{password}")]
        public ActionResult<List<Users>> GetIniciarSesion(string username, string password)
        {
            var users = _context.users.Where(users => users.username.Equals(username) && users.password.Equals(password)).ToList();

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        private bool UsuariosExists(int id)
        {
            return _context.users.Any(e => e.id == id);
        }
    }
}
