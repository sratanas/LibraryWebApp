using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryWebApp.ViewModels
{
    public class AuthorViewModel
    {
        public Book Book { get; set; }
        public Author Author { get; set; }
        public IEnumerable<Book> AuthorBookList { get; set; }
    }
}
