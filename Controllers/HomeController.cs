using Microsoft.AspNetCore.Mvc;
using MyLibraryWebApp.Goodreads;
using MyLibraryWebApp.Models;
using MyLibraryWebApp.Services;
using MyLibraryWebApp.ViewModels;
using System.Linq;

namespace MyLibraryWebApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly IBookDataService _bookDataService;

        public HomeController(IBookDataService bookDataService)
        {
            _bookDataService = bookDataService;
        }

        public IActionResult Index()
        {

            return View();
        }


        public IActionResult AuthorResult(string searchType, string searchInput)
        {
            if (searchType == "Author")
            {
                var model = new AuthorViewModel();
                model.Author = _bookDataService.GetAuthorSearchResults(searchInput);
                model.AuthorBookList = _bookDataService.GetBooksByAuthor(model.Author.Id);
                return View("AuthorResult", model);
            }
            else if (searchType == "Title")
            {
                var model = new TitleResultsViewModel();
                model.BooksByTitle = _bookDataService.SearchTitles(searchInput);

                return View("TitleResult", model);
            }
            else
            {
                return Content("No results found");
            }

        }


        //USING REPOSITORY METHOD
        [HttpGet]
        [Route("/home/authorbooks/{id}")]
        public IActionResult AuthorBooks(int id)
        {

            var model = new AuthorViewModel();
            model.AuthorBookList = _bookDataService.GetBooksByAuthor(id);

            return View(model);
        }

        //USING LINQ
        //[HttpGet]
        //[Route("/home/authorbooks/{id}")]
        //public IActionResult AuthorBooks(int id)
        //{

        //    var model = new AuthorViewModel();
        //    var bookRepo = new BookRepository();

        //    model.AuthorBookList = from b in bookRepo.GetBooks()
        //                           where b.Author.Id == id
        //                           orderby b.Title ascending
        //                           select b;

        //    return View(model);
        //}


        [HttpGet]
        public IActionResult AllBooks()
        {

            var model = new HomeIndexViewModel();

            model.Books = from b in _bookDataService.GetBooks()
                          where b.Title != null
                          orderby b.Title ascending
                          select b;



            return View(model);
        }

        [HttpGet]
        [Route("home/details/{type}/{id}")]
        public IActionResult Details(BookModel book)
        {

            var model = new BookEditViewModel();

            var goodreads = new GetBookByTitle();
            model.Book = _bookDataService.GetBookById(book);
            model.goodreadsList = goodreads.ReturnBookBasedOnTitle(model.Book.Title);

            return View(model);         

        }


        [HttpGet]
        [Route("/home/create")]
        public IActionResult Create()
        {
            var model = new BookEditViewModel();

            model.GenreList = _bookDataService.GetAllGenres();
            model.AuthorList = _bookDataService.GetAuthors();
            model.LocationList = _bookDataService.GetLocations();
          
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                BookModel newBook = new BookModel();

                newBook.Title = model.Title;
                newBook.Genre = model.Book.Genre;
                newBook.Author = model.Book.Author;
                newBook.Location = model.Book.Location;
                newBook.YearPublished = model.YearPublished;
                newBook.Type = model.Type;

                _bookDataService.AddBook(newBook);

                return View("Index");
            }
            else
            {
                return View();
            }


        }

    }
}
