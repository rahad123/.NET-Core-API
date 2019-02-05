using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using BlogProject.Models;
namespace BlogProject.EntityRelationship
{
    public class PostRelation
    {
        private static ModelBuilder modelBuilder;

        public static void Post(ModelBuilder _modelBuilder)
        {
            modelBuilder = _modelBuilder;

            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar");

            modelBuilder.Entity<Post>()
                .Property(p => p.Body)
                .IsRequired()
                .HasMaxLength(2000);

            modelBuilder.Entity<Post>()
                .HasMany(r => r.Comments)
                .WithOne(r => r.Post).IsRequired()
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        } 
    }
}