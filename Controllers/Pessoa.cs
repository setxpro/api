using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CURSO_ASP_.NET.Data;
using CURSO_ASP_.NET.Models;
using Microsoft.AspNetCore.Http;

namespace CURSO_ASP_.NET.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {

        private DataContext _context;

        public PessoaController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("api")]
        public async Task<ActionResult> register([FromBody] Pessoa p)
        {
            _context.Add(p);

            await _context.SaveChangesAsync();

            return Created("Obj pessoa", p);
        }

        [HttpGet("api")]
        public async Task<ActionResult> findOne()
        {
            var data = await _context.pessoa.ToListAsync();
            return Ok(data);
        }

        [HttpGet("api/{id}")]
        public async Task<ActionResult<Pessoa>> GetUser(Guid id)
        {
            if (_context.pessoa == null)
            {
                return NotFound();
            }

            var user = await _context.pessoa.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("api/{id}")]
        public async Task<ActionResult<Pessoa>> UpdateUser(Guid id, [FromBody] Pessoa p)
        {
            p.Id = id;
            _context.pessoa.Update(p);
            await _context.SaveChangesAsync();
            return Ok(p);
        }

        [HttpDelete("api/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (_context.pessoa == null) {
                object messageNotFound = "User not found!";
                return NotFound(messageNotFound);
            }

            var user = _context.pessoa.Where(c => c.Id == id).FirstOrDefault();

            if (user == null) {
                object messageNotRequest = "The requested user does not exist!";
                return NotFound(messageNotRequest);
            }

            // Remove
            _context.pessoa.Remove(user);
             await _context.SaveChangesAsync();

    
            object messageDelete = "User deleted successfully";
            return StatusCode(204, messageDelete);
        }

        // Verify if user exists
        private bool UserExists(Guid id)
        {
            return (_context.pessoa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}