using System.Reflection.Metadata.Ecma335;
using BlogProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace BlogProject.Controllers
{
    //[ServiceFilter(typeof(LogUserActivity))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }
        //[AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var value = await _context.Users.ToListAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<ActionResult> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleUser(int id)
        {
            var value = await _context.Users.SingleOrDefaultAsync(p => p.Id == id);
            if(value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {   
            var deleteUser =  _context.Users.Find(id);
            _context.Users.Remove(deleteUser);
            _context.SaveChanges();

            return Ok("Deleted");
        }

        [HttpPut("{id}")]
        public  IActionResult UpdateUser(int id, User user)
        {
            var updateUser = _context.Users.Find(id);
            updateUser.FistName = user.FistName;
            updateUser.LastName = user.LastName;
            updateUser.Email = user.Email;
            updateUser.ContactPhone = user.ContactPhone;
            updateUser.Password = user.Password;
             _context.SaveChanges();
            return Ok("Updated");
        }
    }
}