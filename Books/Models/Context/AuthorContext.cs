using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Books.Models.Entities;

namespace Books.Models.Context
{
    public class AuthorContext : DbContext
    {
        static AuthorContext()
        {
            System.Data.Entity.Database.SetInitializer(new ContextInitializer());
        }

        //public AuthorContext() : base("AuthorContext") { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; } 
    }
}