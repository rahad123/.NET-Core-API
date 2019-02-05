using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlogProject.Models
{
    public class User
    {
        public User()
        {
            this.Posts = new List<Post>();
        }


        [Key]
        public int Id { get; set; }

        public string FistName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int ContactPhone { get; set; }

        public string Password {get; set;}

        public List<Post> Posts { get; set; }
    }
}