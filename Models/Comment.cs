using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlogProject.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }
    }
}