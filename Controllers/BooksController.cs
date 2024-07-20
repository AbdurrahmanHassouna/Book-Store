using AprilBookStore.DataAccess;
using AprilBookStore.Models;
using AprilBookStore.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.RegularExpressions;
using X.PagedList;

namespace AprilBookStore.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class BooksController : Controller
    {
        private readonly IData data;
        private readonly IWebHostEnvironment env;

        public BooksController(IData data, IWebHostEnvironment hostEnvironment)
        {
            this.data = data;
            this.env = hostEnvironment;
        }

        [AcceptVerbs("GET", "POST")]
        [AllowAnonymous]
        public async Task<IActionResult> AutoComplete(string term)
        {
            var result = (await data.SearchBook(term)).Select(b => b.Name).ToList();
            return Json(result);
        }

        public async Task<IActionResult> Name(string Name)
        {
            if ((await data.SearchBook(Name)).Any(b => b.Name == Name))
            {
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
       public async Task<ActionResult> Index(string name, int? categoryId, decimal? minPrice, decimal? maxPrice, int? page)
        {

            ICollection<Book> books;

            if (!string.IsNullOrEmpty(name))
            {
                 books = await data.SearchBook(name);
            }
            else
            {
                books = data.GetBooks().OrderBy(b => b.Name).ToList();
            }

            if (categoryId.HasValue)
            {
                books = books.Where(b => b.CategoryId == categoryId.Value).ToList();
            }

            if (minPrice.HasValue)
            {
                books = books.Where(b => b.Price >= minPrice.Value).ToList();
            }

            if (maxPrice.HasValue)
            {
                books = books.Where(b => b.Price <= maxPrice.Value).ToList();
            }

            ViewData["NameFilter"] = name;
            ViewData["CategoryFilter"] = categoryId;
            ViewData["MinPrice"] = minPrice;
            ViewData["MaxPrice"] = maxPrice;

            ViewBag.Categories = new SelectList(data.GetCategories(), "Id", "Name");

            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(await books.ToPagedListAsync(pageNumber, pageSize));
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
                var newBook = new Book
                {
                    Name = book.Name,
                    Description = book.Description,
                    AuthorId = book.AuthorId,
                    CategoryId = book.CategoryId,
                    BookStar = book.BookStar,
                    ISBN = book.ISBN,
                    Format = book.Format,
                    Price = book.Price,
                    PublicationYear = book.PublicationYear,
                    IsDeleted = false,
                    IsVisible = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                if (book.BookCoverFile != null && book.BookCoverFile.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + book.BookCoverFile.FileName;
                    string imagePath = Path.Combine("/book-covers/UploadedCovers", uniqueFileName);
                    string filePath = Path.Combine(env.ContentRootPath + "\\wwwroot\\book-covers\\UploadedCovers", uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        book.BookCoverFile.CopyTo(fileStream);
                    }
                    newBook.ImgPath = imagePath;
                }

                data.AddBook(newBook);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(data.GetAuthors(), "Id", "Name", book.AuthorId);
            ViewBag.CategoryId = new SelectList(data.GetCategories(), "Id", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            Book? book = data.GetBook(id.Value);

            if (book == null)
            {
                return NotFound();
            }

            EditBookViewModel viewModel = new EditBookViewModel
            {
                Id = id.Value,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                BookStar =book.BookStar??0,
                Description = book.Description,
                Format = book.Format,
                ISBN=book.ISBN,
                QuantityInStock = book.QuantityInStock,
                PublicationYear=book.PublicationYear,
                Name = book.Name,
                Price=book.Price,
                IsDeleted= book.IsDeleted,
                IsVisible= book.IsVisible,
                CreatedDate = book.CreatedDate
            };
            ViewBag.AuthorId = new SelectList(data.GetAuthors(), "Id", "Name", book.AuthorId);
            ViewBag.CategoryId = new SelectList(data.GetCategories(), "Id", "Name", book.CategoryId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditBookViewModel editedBook)
        {
            var book = data.GetBook(editedBook.Id);
            if (book == null)
            {
                return NotFound();
            }
            if (!((await data.SearchBook(editedBook.Name)).Any(b => b.Name == editedBook.Name) && editedBook.Name!=book.Name))
            {

                book.Name = editedBook.Name;
                book.Format = editedBook.Format;
                book.ISBN = editedBook.ISBN;
                book.Price = editedBook.Price;
                book.IsDeleted= editedBook.IsDeleted;
                book.IsVisible=editedBook.IsVisible;
                book.PublicationYear = editedBook.PublicationYear;
                book.QuantityInStock = editedBook.QuantityInStock;
                book.AuthorId = editedBook.AuthorId;
                book.CategoryId = editedBook.CategoryId;
                book.UpdatedDate = DateTime.Now;

                if (editedBook.BookCoverFile != null && editedBook.BookCoverFile.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + editedBook.BookCoverFile.FileName;
                    string imagePath = Path.Combine("/book-covers/UploadedCovers", uniqueFileName);
                    string filePath = Path.Combine(env.ContentRootPath + "\\wwwroot\\book-covers\\UploadedCovers", uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        editedBook.BookCoverFile.CopyTo(fileStream);
                    }
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    book.ImgPath = imagePath;
                }

                if (ModelState.IsValid)
                {
                    data.UpdateBook(book);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("Name", "This name is used !!");
            }
            ViewBag.AuthorId = new SelectList(data.GetAuthors(), "Id", "Name", book.AuthorId);
            ViewBag.CategoryId = new SelectList(data.GetCategories(), "Id", "Name", book.CategoryId);
            return View(editedBook);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            Book book = data.GetBook(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book? book = data.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            data.DeleteBook(book.Id);
            try
            {
                string fileName = Path.GetFileName(book.ImgPath.Split('/').Last());
                string filePath = Path.Combine(env.WebRootPath, "book-covers/UploadedCovers", fileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {

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
    }
}
