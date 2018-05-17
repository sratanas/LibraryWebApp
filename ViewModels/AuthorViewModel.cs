using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using System.Collections.Generic;

namespace MyLibraryWebApp.ViewModels
{
    public class AuthorViewModel
    {
        public Book Book { get; set; }
        public Author Author { get; set; }

        [FromQuery]
        public string SearchType { get; set; }

        [FromQuery]
        public string SearchInput { get; set; }
        public IEnumerable<Book> AuthorBookList { get; set; }
    }
}
