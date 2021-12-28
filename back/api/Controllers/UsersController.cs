using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterApi.Data;
using TwitterApi.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwitterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApiContext _context;

        public UsersController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Index()
        {
            return new[]
            {
                new User {
                    Name = "John"
                },
                new User {
                    Name = "Elijah"
                }
            };
        }

        // GET api/Users/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Show(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/Users
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            try {
                _context.Users.Add(user);
                _context.SaveChanges();
            } catch (DbUpdateException) {
                return UnprocessableEntity();
            }

            return CreatedAtAction("Show", new { id = user.Id }, user);
        }
    }
}
