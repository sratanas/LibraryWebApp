
using MyLibrary.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyLibraryWebApp.ViewModels
{
    public class BookEditModel
    {

        [Required, MaxLength(80)]
        public Book Book { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public Genre Genre { get; set; }
        
        public IEnumerable<Genre> GenreList { get; set; }
        public IEnumerable<Author> AuthorList { get; set; }
    }
}
