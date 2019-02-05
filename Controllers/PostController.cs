using BlogProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace BlogProject.Controllers
{
    //[Produces("application/json")]
    // [Route("api/[controller]")]
    // [ApiController]
    public class PostController : ControllerBase
    {
        private MyDbContext _context;

        public PostController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/users/{id}/posts")]
        public IActionResult GetPost(int id)
        {
            // var posts = _context.Users
            //     .Include(p => p.Posts)
            //     .Where(p => p.Id == id)
            //     .ToList();
                var posts = _context.Users
                    .Include(p => p.Posts)
                    .Where(p => p.Id == id)
                    .ToList();
            return Ok(posts);
        }

        [HttpPost("api/users/{id}/posts")]
        //[Route("api/users/{id}/posts")]
        public IActionResult CreatePost(Post post)
        {
            //var post = Mapper.Map<PostDto, Post>(postDto)
            //return Ok(post);
            _context.Posts.Add(post);
            _context.SaveChanges();
            //postDto.Id = post.Id;
           return Ok(post);
        }

         [HttpGet("api/users/{userId}/posts/{postId}")]
        //[Route("api/users/{userId}/posts/{postId}")]
        public IActionResult SinglePost( int userId,int postId)
        {
                
            return Ok();
        }

        [HttpDelete]
        [Route("api/users/{userId}/posts/{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var deletePost = await _context.Posts.FindAsync(postId);
            _context.Posts.Remove(deletePost);
            await _context.SaveChangesAsync();

            return Ok(deletePost);
        }

        [HttpPut]
        [Route("api/users/{userId}/posts/{postId}")]
        public IActionResult EditPost(int postId, Post post)
        {
            var editPost = _context.Posts.Find(postId);
            editPost.Title = post.Title;
            editPost.Body = post.Body;
            // editPost.UserId = post.UserId;
            _context.SaveChanges();

            return Ok("Updated");
        }
    }
}