using BlogProject.Models;
using System.Collections.Generic;
namespace BlogProject.ViewModel
{
    public class BaseViewModel
    {
        public User Users { get; set; }

        public Post Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}