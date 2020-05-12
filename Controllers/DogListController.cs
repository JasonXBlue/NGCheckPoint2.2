using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using capstone.Data;
using capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace capstone.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DogListController : ControllerBase
    {
        private ApplicationDbContext _context;

        public DogListController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Dog> Get()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Dog[] dogs = null;
            dogs = _context.Dogs.Where(d => d.UserId == userId).ToArray();

            return dogs;

        }
        [HttpPost]
        public Dog Post([FromBody] Dog dog)
        {
            dog.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _context.Dogs.Add(dog);
            _context.SaveChanges();
            return dog;
        }
    }
}
