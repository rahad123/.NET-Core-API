using Microsoft.EntityFrameworkCore;
using BlogProject.Models;
namespace BlogProject.EntityRelationship
{
    public class UserRelation
    {
        private static ModelBuilder modelBuilder;

        public static void User(ModelBuilder _modelBuilder)
        {

            modelBuilder = _modelBuilder;

            modelBuilder.Entity<User>()
               .Property(p => p.FistName)
               .IsRequired()
               .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .HasMany(r => r.Posts)
                .WithOne(r => r.User).IsRequired()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}