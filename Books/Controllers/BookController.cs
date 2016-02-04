using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Books.Models.Context;
using Books.Models.Entities;

namespace Books.Controllers
{
    public class BookController : Controller
    {
        private AuthorContext db = new AuthorContext();
        // GET: Book
        public ActionResult Index()
        {
            return RedirectToAction("GetAuthor", new {id = 1});
            //return RedirectToAction("Test", new { id = 1 });
        }

        public ActionResult GetAuthor(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        [HttpPost]
        public ActionResult SaveAuthor(Author author, Book[] Books)
        {
            if (author == null)
            {
                return HttpNotFound();
            }

            Author dbAuthor = db.Authors.Find(author.Id);
            if (dbAuthor == null)
            {
                return HttpNotFound(); 
            }
            dbAuthor.Books.Clear();
            dbAuthor.FirstName = author.FirstName;
            dbAuthor.LastName = author.LastName;
            dbAuthor.Patronymic = author.Patronymic;

            foreach (Book book in author.Books)
            {
                Genre genreExists = db.Genres.Where(g => g.Name == book.Genre.Name).FirstOrDefault();
                if (genreExists == null)
                {
                    db.Genres.Add(book.Genre);
                }
                else
                {
                    book.Genre = genreExists;
                }

                if (book.Id == 0)
                {
                    db.Books.Add(book);
                }
                dbAuthor.Books.Add(book);
                db.SaveChanges();
            }

            db.Entry(dbAuthor).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("GetAuthor", new {id = author.Id});
        }

        public ActionResult Test(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        // Для поддержки возможности удаления необходимо реализовать что-то вроде этого.
        // Заместо этого есть подход event sourcing.
        // Переделать в будущем.
        public ActionResult SaveTest(string[] name, string[] genre, int[] pages)
        {
            if (name == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}