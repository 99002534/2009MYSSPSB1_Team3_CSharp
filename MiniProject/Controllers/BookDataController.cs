using System.Linq;
using System.Web.Mvc;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class BookDataController : Controller
    {
        public ViewResult AllBooks()
        {
            var context = new MyDatabaseEntities();
            var model = context.BooksTables.ToList();
            return View(model);
        }

        public ViewResult Find(string id)
        {
            int bookId = int.Parse(id);
            var context = new MyDatabaseEntities();
            var model = context.BooksTables.FirstOrDefault((e) => e.BookID == bookId);
            return View(model);

        }
        [HttpPost]
        public ActionResult Find(BooksTable book)
        {
            var context = new MyDatabaseEntities();
            var model = context.BooksTables.FirstOrDefault((e) => e.BookID == book.BookID);
            model.BookName = book.BookName;
            model.BookAuthor = book.BookAuthor;
            model.BookPrice = book.BookPrice;
            context.SaveChanges();
            return RedirectToAction("AllBooks");
        }

        public ViewResult NewBook()
        {
            var model = new BooksTable();
            return View(model);
        }

        [HttpPost]

        public ActionResult NewBook(BooksTable book)
        {
            var context = new MyDatabaseEntities();
            context.BooksTables.Add(book);
            context.SaveChanges();
            return RedirectToAction("AllBooks");
        }
        public ActionResult Delete(string id)
        {
            int bookId = int.Parse(id);
            var context = new MyDatabaseEntities();
            var model = context.BooksTables.FirstOrDefault((e) => e.BookID == bookId);
            context.BooksTables.Remove(model);
            context.SaveChanges();
            return RedirectToAction("AllBooks");
        }

    }
}