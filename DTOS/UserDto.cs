using System.Collections.Generic;
using BlogProject.Models;
namespace BlogProject.DTOS
{
    public class UserDto
    {
        public UserDto()
        {
            this.Posts = new List<PostDto>();
        }

        public int Id { get; set; }

        public string FistName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int ContactPhone { get; set; }

        public string Password {get; set;}

        public List<PostDto> Posts { get; set; }
    }
}