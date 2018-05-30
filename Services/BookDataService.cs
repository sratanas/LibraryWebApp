using MyLibrary.Data;
using MyLibraryWebApp.Models;
using System.Collections.Generic;

namespace MyLibraryWebApp.Services
{
    public class BookDataService : IBookDataService
    {

        private readonly IBookRepository _getBooks;
        private readonly IAuthorRepository _getAuthors;
        private readonly IGenreRepository _getGenres;
        private readonly ILocationRepository _getLocations;

        
        public BookDataService(IBookRepository getBooks, IAuthorRepository getAuthors, IGenreRepository getGenres, ILocationRepository getLocations)
        {
            _getBooks = getBooks;
            _getAuthors = getAuthors;
            _getGenres = getGenres;
            _getLocations = getLocations;
            
        }


        public IEnumerable<IBook> GetBooks()
        {
            return _getBooks.GetBooks();
        }

        public IBook GetBookById<T>(T book) where T : IFavorites
        {
            return _getBooks.GetBookById(book);
        }

        public IEnumerable<IBook> GetBooksByAuthor(int id)
        {
            return _getBooks.GetBooksByAuthor(id);
        }

       

        public IAuthor GetAuthorSearchResults(string searchParam)
        {
            return _getAuthors.GetAuthorSearchResults(searchParam);
        }

        public List<IAuthor> GetAuthors()
        {
            return _getAuthors.GetAllAuthors();
        }

        public List<IBook> SearchTitles(string searchParam)
        {
            return _getBooks.SearchTitles(searchParam);
        } 

        public void AddBook(IBook book)
        {
            _getBooks.AddBook(book);
        }

        public List<IGenre> GetAllGenres()
        {
            return _getGenres.GetAllGenres();
        }
        public IGenre GetGenreById(int genreId)
        {
           return _getGenres.GetGenreById(genreId);
        }

        public List<ILocation> GetLocations()
        {
           return _getLocations.GetAllLocations();
        }

    }
}
