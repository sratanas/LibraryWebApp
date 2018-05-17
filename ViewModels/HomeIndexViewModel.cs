using MyLibrary.Data;
using System.Collections.Generic;

namespace MyLibraryWebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public Book Book { get; set; }
        
    }
}
