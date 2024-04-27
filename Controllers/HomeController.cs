using AprilBookStore.DataAccess;
using AprilBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AprilBookStore.Controllers
{
    public class HomeController : Controller
    {
        private IData data;
        public HomeController(IData data)
        {
            this.data = data;
        }
        public ActionResult Index(int? page)
        {
            var books = data.GetBooks().Where(b => b.IsVisible==true && b.IsDeleted==false).OrderBy(b => b.Name);
            return View(books.ToPagedList(page ?? 1, 25));
        }
        [HttpPost]
        public ActionResult Index(int? page, string Search)
        {
            List<Book> books;
            books = data.SearchBook(Search).Where(b => b.IsVisible==true && b.IsDeleted==false).ToList();

            return View(books.ToPagedList(page ?? 1, 25));
        }
    }
}
