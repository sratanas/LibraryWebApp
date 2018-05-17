
using MyLibrary.Data;
using System.Collections.Generic;

namespace MyLibraryWebApp.ViewModels
{
    public class BookEditModel
    {

        public Book Book { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public Genre Genre { get; set; }
        public Location Location { get; set; }
        public Author Author { get; set; }
        public string Type { get; set; }
        public int YearPublished { get; set; }
        
        public IEnumerable<Genre> GenreList { get; set; }
        public IEnumerable<Author> AuthorList { get; set; }
        public IEnumerable<Location> LocationList { get; set; }
        public IFavorites Favorite { get; set; }
    }
}
