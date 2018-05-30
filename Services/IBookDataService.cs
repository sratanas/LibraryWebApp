using MyLibrary.Data;
using MyLibraryWebApp.Models;
using System.Collections.Generic;

namespace MyLibraryWebApp.Services
{
    public interface IBookDataService
    {
        IEnumerable<IBook> GetBooks();
        IEnumerable<IBook> GetBooksByAuthor(int id);
        List<IAuthor> GetAuthors();
        IAuthor GetAuthorSearchResults(string searchParam);
        List<IBook> SearchTitles(string title);
        void AddBook(IBook book);
        List<IGenre> GetAllGenres();
        IGenre GetGenreById(int genreId);
        List<ILocation> GetLocations();
        IBook GetBookById<T>(T bookToSearch) where T : IFavorites;



    }
}
