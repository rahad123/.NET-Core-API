using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using BlogProject.Models;
using System.Collections.Generic;
using BlogProject.EntityRelationship;
namespace BlogProject.EntityRelationship
{
    public class Base
    {
        public static ModelBuilder modelBuilder;
        
        public static void BaseRelation(ModelBuilder _modelBuilder)
        {
            modelBuilder = _modelBuilder;
            UserRelation.User(modelBuilder);
            PostRelation.Post(modelBuilder);
        }
    }
}