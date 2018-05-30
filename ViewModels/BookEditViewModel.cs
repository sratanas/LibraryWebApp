
using MyLibrary.Data;
using MyLibraryWebApp.Goodreads;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyLibraryWebApp.ViewModels
{
    public class BookEditViewModel
    {

        public IBook Book { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public int YearPublished { get; set; }
        public string IsFavorite { get; set; }
        
        public IEnumerable<IGenre> GenreList { get; set; }
        public IEnumerable<IAuthor> AuthorList { get; set; }
        public IEnumerable<ILocation> LocationList { get; set; }
        public IFavorites Favorite { get; set; }

        public Task<GoodreadsResponse> goodreadsList { get; set; }
    }
}
