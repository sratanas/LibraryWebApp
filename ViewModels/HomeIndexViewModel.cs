using MyLibrary.Data;
using MyLibraryWebApp.Models;
using System.Collections.Generic;

namespace MyLibraryWebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<IBook> Books { get; set; }
        //public Book Book { get; set; }
        
    }
}
