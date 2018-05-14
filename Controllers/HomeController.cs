using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibraryWebApp.ViewModels;

namespace MyLibraryWebApp.Controllers
{
    public class HomeController : Controller
    {


        //Get request using database
        public IActionResult Index()
        {
            //var bookRepo = new BookRepository();
            //var model = new HomeIndexViewModel();
            //model.Books = bookRepo.GetBooks();


            return View();
        }
        [HttpGet]
        [Route("/home/authorbooks/{id}")]
        public IActionResult AuthorBooks(int id)
        {
        
            var model = new AuthorViewModel();
            var repo = new BookRepository();
            model.AuthorBookList = repo.GetBooksByAuthor(id);

            return View(model);
        }

        //[HttpGet]
        //public IActionResult Index(string searchParam)
        //{
        //    var model = new AuthorViewModel();
        //    model.Author = AuthorRepository.GetAuthorSearchResults(searchParam);

        //    return View(model);
        //}



        [HttpGet]
        public IActionResult AllBooks()
        {
            var bookRepo = new BookRepository();
            var model = new HomeIndexViewModel();
            model.Books = bookRepo.GetBooks();


            return View(model);
        }


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

            var location = new LocationRepository();
            model.LocationList = location.GetAllLocations();
          
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
                newBook.Author = model.Author;
                newBook.Location = model.Location;
                newBook.YearPublished = model.YearPublished;
                newBook.Type = model.Type;

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
