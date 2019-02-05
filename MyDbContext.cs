using System.Data.Common;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using BlogProject.Models;
using System.Collections.Generic;
using BlogProject.EntityRelationship;
using System.Data;
using Z.EntityFramework.Plus;
using System;

namespace BlogProject
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext>options)
            :base(options)
            {}

        public DbSet<User> Users {get; set;}

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

         protected override void OnModelCreating(ModelBuilder builder)
         {
            Base.BaseRelation(builder);

            builder.Entity<User>()
            .HasData(
                new User { Id = 1, FistName = "Rahad", LastName = "Saidul", ContactPhone = 01799052270,Email = "rahaddiu@gmail.com",Password = "143"},
                new User {Id = 2, FistName = "Sohag", LastName = "Jaidul", ContactPhone = 01726688748,Email = "sohag@gmail.com",Password = "143-15"}
                );

            builder.Entity<Post>()
            .HasData(
                new Post { Id = 1, Title = "First Tittle", Body = "First Body", UserId = 1},
                new Post { Id = 2, Title = "Second Tittle", Body = "Second Body", UserId = 2}
                );

            builder.Entity<Comment>()
            .HasData(
                new Comment { Id = 1, Message = "First Message", PostId = 1},
                new Comment { Id = 2, Message = "Second Message", PostId = 2}
                );
        }

        internal object Query<T>(string v)
        {
            throw new NotImplementedException();
        }
    }
}