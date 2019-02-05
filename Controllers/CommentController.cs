using System.Collections.Immutable;
using System.Data;
using BlogProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BlogProject.ViewModel;
using Z.EntityFramework.Classic;
//using Z.EntityFramework.Plus;
using Dapper;

namespace BlogProject.Controllers
{
    public class CommentController : ControllerBase
    {
        private MyDbContext _context;
        private readonly DapperConnection _dbConnection;

        public CommentController(MyDbContext context, DapperConnection dbConnection)
        {
            _context = context;
            _dbConnection = dbConnection;
        }

        [HttpGet]
        [Route("api/users/{userId}/posts/{postId}/comments")]
        public IActionResult GetComment(int userId, int postId)
        {
            //var value = _context.Users.Join(u => u.posts);
            // var value = _context.Users
            //         .IncludeFilter(p => p.Posts
            //         .Where(e => e.Id == postId)
            //         .include(d => d.comments))
            //         .Where(p => p.Id == userId);
            var singlePost = _context.Users
                .Where(p => p.Id == userId);

            var singlePost1 = _context.Posts
                .Where(p => p.Id == postId);

            // var singlePost2 = _context.Us
            //     .Where(p => p.Id == userId); 
            return Ok(singlePost);
            return Ok(singlePost1);
        }
    }
}