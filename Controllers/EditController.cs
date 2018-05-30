using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibraryWebApp.ViewModels;

namespace MyLibraryWebApp.Controllers
{
    public class EditController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("home/details/{book.type}/edit/{book.id}")]
        public IActionResult Edit(Book book)
        {
            var genreRepo = new GenreRepository();
            var model = new BookEditViewModel();
            model.GenreList = genreRepo.GetAllGenres();
            model.AuthorList = new AuthorRepository().GetAllAuthors();

            var location = new LocationRepository();
            model.LocationList = location.GetAllLocations();
            var _bookRepo = new BookRepository();
            model.Book = _bookRepo.GetBookById(book);



            return View(model);
        }

        [HttpPost]
        //[ActionName("Edit")]
        [Route("home/details/{model.type}/edit/{model.id}")]
        public IActionResult Edit(BookEditViewModel model)
        {
            var bookRepo = new BookRepository();
           // var model = new BookEditModel();

            if (ModelState.IsValid)
            {
                var editedBook = new Book();
                editedBook.Id = model.Id;
                editedBook.Title = model.Book.Title;
                editedBook.Genre = model.Book.Genre;
                editedBook.Author = model.Book.Author;
                editedBook.Location = model.Book.Location;
                editedBook.YearPublished = model.Book.YearPublished;
                editedBook.Type = model.Book.Type;

                bookRepo.UpdateBookInfo(editedBook);

                //this doesn't work
                return View("home/details/{editedBook.type}/{editedBook.id}");
            }
            else
            {
                return View();
            }


        }
    }
}