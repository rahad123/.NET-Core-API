using Microsoft.EntityFrameworkCore;
using BlogProject.Models;
namespace BlogProject.EntityRelationship
{
    public class CommentRelation
    {
         private static ModelBuilder modelBuilder;

         public static void Comment(ModelBuilder _modelBuilder)
         {
             modelBuilder = _modelBuilder;

             modelBuilder.Entity<Comment>()
               .Property(p => p.Message)
               .IsRequired()
               .HasMaxLength(2000);
         }
    }
}