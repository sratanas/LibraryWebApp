using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibraryWebApp.Models;
using System.Collections.Generic;

namespace MyLibraryWebApp.ViewModels
{
    public class AuthorViewModel
    {
        public IAuthor Author { get; set; }

        [FromQuery]
        public string SearchType { get; set; }

        [FromQuery]
        public string SearchInput { get; set; }

        public IEnumerable<IBook> AuthorBookList { get; set; }
        public string Message { get; set; }

    }
}
