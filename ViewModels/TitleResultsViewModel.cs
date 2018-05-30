using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryWebApp.ViewModels
{
    public class TitleResultsViewModel
    {
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public Location Location { get; set; }
        public string Type { get; set; }
        public string IsFavorite { get; set; }
        public IEnumerable<IBook> BooksByTitle { get; set; }
    }
}
