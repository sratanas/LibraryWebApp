using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibraryWebApp.Services;
using MyLibraryWebApp.ViewModels;

namespace MyLibraryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IBookData _bookData;
        private IGreeter _greeter;

        //home controller getting some object that implements IBookData and will deliver 
        public HomeController(IBookData bookdata, IGreeter greeter)
        {
            _bookData = bookdata;
            _greeter = greeter;

        }

        //Get request using database
        public IActionResult Index()
        {
            var bookRepo = new BookRepository();
            var model = new HomeIndexViewModel();
            model.Books = bookRepo.GetBooks();


            return View(model);
        }

        //public IActionResult Index()
        //{

        //    var model = new HomeIndexViewModel();
        //    model.Books = _bookData.GetAll();



        //    return View(model);
        //}

        [Route("home/details/{type}/{id}")]
        public IActionResult Details(Book book)
        {
            var bookRepo = new BookRepository();
            var model = new BookEditModel();
                model.Book = bookRepo.GetBookById(book);


                return View(model);
           

        }

        [HttpGet]
        public IActionResult Create()
        {
            var genreRepo = new GenreRepository();
            var model = new BookEditModel();
            model.GenreList = genreRepo.GetAllGenres();
            model.AuthorList = AuthorRepository.GetAllAuthors(); 


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookEditModel model)
        {
            var bookRepo = new BookRepository();

            if (ModelState.IsValid)
            {
                var newBook = new Book();
                newBook.Title = model.Title;
                newBook.Genre = model.Genre;

                bookRepo.AddBook(newBook);

                return RedirectToAction(nameof(Details), new { id = newBook.Id });
            }
            else
            {
                return View();
            }


        }
    }
}
