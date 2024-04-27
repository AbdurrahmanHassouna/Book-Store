using AprilBookStore.DataAccess;
using AprilBookStore.Models;
using AprilBookStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;



namespace AprilBookStore.Controllers
{
    public class BooksController : Controller
    {
        private IData data;
        private IWebHostEnvironment env;
        public BooksController(IData data ,IWebHostEnvironment hostEnvironment)
        {
            this.data = data;
            this.env = hostEnvironment;
        }

        public JsonResult AutoComplete(string term)
        {
           var result = data.SearchBook(term).Select(b=>b.Name).ToList();
           return Json(result);
        }
        // GET: Books
        public JsonResult Name(string Name)
        {
            if(data.SearchBook(Name).Any(b => b.Name==Name)) { 
            return Json(false);
            }
            return Json(true);
        }
        public ActionResult Index(int? page)
        {
            var books = data.GetBooks().OrderBy(b => b.Name);
            return View(books.ToPagedList(page ?? 1, 25));
        }
        [HttpPost]
        public ActionResult Index(int? page, string Search)
        {
            List<Book> books;
            books = data.SearchBook(Search).ToList();
            
            return View(books.ToPagedList(page ?? 1, 25));
        }


        // GET: Books/Details/5

        public ActionResult Details(int id)
        {
            
            Book? book = data.GetBook(id);
            if (book == null)
            {
                return View("NotFound");
            }
            return View(book);
        }

        // GET: Books/Create

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(data.GetAuthors(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(data.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var newbook = new Book{
                    Description = book.Description,
                    AuthorId=book.AuthorId.Value,
                    CategoryId=book.CategoryId.Value,
                    BookStar=book.BookStar,
                    ISBN=book.ISBN.Value,
                    Format = book.Format,
                    Price = book.Price.Value,
                    PublicationYear = book.PublicationYear
                   
                };
                newbook.Name = book.Name;
                if (book.BookCoverFile != null && book.BookCoverFile.Length > 0)
                {
                    string uniquefileName = Guid.NewGuid().ToString()+"_"+book.BookCoverFile.FileName;
                    string filePath = Path.Combine(env.ContentRootPath+"\\book-covers\\UploadedCovers", uniquefileName);
                    book.BookCoverFile.CopyTo(new FileStream(env.ContentRootPath+"\\book-covers\\UploadedCovers", FileMode.Create));
                    newbook.ImgPath = filePath;
                }
                newbook.IsDeleted=false;
                newbook.IsVisible=true;
                newbook.CreatedDate = DateTime.Now;
                newbook.UpdatedDate = DateTime.Now;
                

                data.AddBook(newbook);
                
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(data.GetAuthors(), "Id", "Name", book.AuthorId);
            ViewBag.CategoryId = new SelectList(data.GetCategories(), "Id", "Name", book.CategoryId);
            return View(book);
        }
/*
        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = data.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(data.Authors, "Id", "Name", book.AuthorId);
            ViewBag.CategoryId = new SelectList(data.Categories, "Id", "Name", book.CategoryId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,QuantityInStock,BookStar,Format,ISBN,Price,CategoryId,AuthorId,IsDeleted,IsVisible")] Book book)
        {
            Book bookData = data.Books.Where(b => b.Id == book.Id).FirstOrDefault();
            book.CreatedDate= bookData.CreatedDate;
            book.UpdatedDate=DateTime.Now;
            book.img_path = bookData.img_path;
            book.Description=bookData.Description;
            if (book.IsDeleted == null)
            {
                book.IsDeleted= bookData.IsDeleted;
            }
            book.PublicationYear= bookData.PublicationYear;

            if (ModelState.IsValid)
            {
                data.Books.AddOrUpdate(book);
                data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(data.Authors, "Id", "Name", book.AuthorId);
            ViewBag.CategoryId = new SelectList(data.Categories, "Id", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = data.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Book book = data.Books.Find(id);
            data.Books.Remove(book);
            data.SaveChanges();
            try
            {
                string fileName = Path.GetFileName(book.img_path.Split('/').Last());
                string filePath = Path.Combine(Server.MapPath(book.img_path));
                FileInfo fileInfo = new FileInfo(filePath);
                fileInfo.Delete();
            }
            catch (Exception ex)
            {
                // what to write 18:31
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                data.Dispose();
            }
            base.Dispose(disposing);
        }
        public static int Stock(int id)
        {
            BookStore data = new BookStore();
            int num = data.Books.Where(d => d.Id == id).Single().QuantityInStock;
            return num;
        }*/
    }
}
