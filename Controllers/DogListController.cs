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
            _context.Dogs.Where(d => d.User.Id == userId).ToArray();

            return dogs;

            // Dog[] dogs = null;
            // using (var context = new ApplicationDbContext())
            // {
            //     dogs = context.Dogs.ToArray();
            // }
            // return dogs;

        }
        [HttpPost]
        public Dog Post([FromBody] Dog dog)
        {
            _context.Dogs.Add(dog);
            _context.SaveChanges();
            return dog;

            // using (var context = new ApplicationDbContext())
            // {
            //     context.Dogs.Add(dog);
            //     context.SaveChanges();
            // }
            // return dog;
        }
    }
}
