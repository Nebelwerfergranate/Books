using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Books.Models.Entities;

namespace Books.Models.Context
{
    public class ContextInitializer : DropCreateDatabaseAlways<AuthorContext>
    {
        protected override void Seed(AuthorContext context)
        {
            Genre detective = new Genre("детектив");
            Genre fantastic = new Genre("фантастика");
            Genre epicNovel = new Genre("роман-эпопея");
            context.Genres.AddRange(new List<Genre> {detective, fantastic, epicNovel});

            Book warAndPeace = new Book
            {
                Name = "Война и мир",
                Genre = epicNovel,
                Pages = 1274
            };

            Book theWarOfTheWorlds = new Book
            {
                Name = "Война миров",
                Genre = fantastic,
                Pages = 448
            };

            Book murderOnTheOrientExpress = new Book
            {
                Name = "Убийство в «Восточном экспрессе»",
                Genre = detective,
                Pages = 320
            };

            context.Books.AddRange(new List<Book> {warAndPeace, theWarOfTheWorlds, murderOnTheOrientExpress});

            
            
            Author agatha = new Author
            {
                FirstName = "Агата",
                LastName = "Кристи",
                Books = new List<Book> { murderOnTheOrientExpress}
            };
            
            Author herbert = new Author
            {
                FirstName = "Герберт",
                LastName = "Уэллс",
                Books = new List<Book> { theWarOfTheWorlds}
            };

            Author lev = new Author
            {
                FirstName = "Лев",
                LastName = "Толстой",
                Patronymic = "Николаевич",
                Books = new List<Book> { warAndPeace}
            };

            context.Authors.AddRange(new List<Author> {agatha, herbert, lev});
            context.SaveChanges();
            base.Seed(context);
        }
    }
}