using MyLibrary.Data;

namespace MyLibraryWebApp.Models
{
    public class BookModel : IBook
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public IAuthor Author { get; set; }
        public BookOnLoan BookOnLoan { get; set; }
        public IGenre Genre { get; set; }
        public string IsFavorite { get; set; }
        public ILocation Location { get; set; }
        public string Type { get; set; }
        public int YearPublished { get; set; }
    }
}
