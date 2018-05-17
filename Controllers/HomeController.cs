using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibraryWebApp.ViewModels;

namespace MyLibraryWebApp.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {

            return View();
        }


        public IActionResult AuthorResult(string searchType, string searchInput)
        {
            var model = new AuthorViewModel();
            model.Author = AuthorRepository.GetAuthorSearchResults(searchInput);

            return View(model);
        }

        //This returns the correct string
        //public string AuthorSearch(string searchType, string searchInput)
        //{
           

        //    return "The Author was " + searchInput + " The search type was "+searchType;
        //}

        [HttpGet]
        [Route("/home/authorbooks/{id}")]
        public IActionResult AuthorBooks(int id)
        {
        
            var model = new AuthorViewModel();
            var _bookRepo = new BookRepository();

            model.AuthorBookList = _bookRepo.GetBooksByAuthor(id);

            return View(model);
        }





        [HttpGet]
        public IActionResult AllBooks()
        {
            var _bookRepo = new BookRepository();

            var model = new HomeIndexViewModel();
            model.Books = _bookRepo.GetBooks();


            return View(model);
        }

        [HttpGet]
        [Route("home/details/{type}/{id}")]
        public IActionResult Details(Book book)
        {
            var _bookRepo = new BookRepository();

            var model = new BookEditModel();
                model.Book = _bookRepo.GetBookById(book);


                return View(model);         

        }
        //public Task<IActionResult> AddToFavorites(IFavorites favorite)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        FavoritesRepository.AddToFavorites(favorite);

        //        return View();
        //    }
        //}


        //[ActionName("Details")]
        //[HttpPut]
        //public IActionResult AddToFavorites(IFavorites favorite)
        //{
        //   FavoritesRepository.AddToFavorites(favorite);

        //    return Ok();

        //}

        [HttpGet]
        [Route("/home/create")]
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
