using MyLibraryWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyLibraryWebApp.Services
{
    public class InMemoryBookData : IBookData
    {
        public InMemoryBookData()
        {
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "Where the Red Fern Grows" },
                new Book { Id = 2, Title = "The Hobbit" },
                new Book { Id = 3, Title = "Journey to the End of the Night" }
            };
        }



        public IEnumerable<Book> GetAll()
        {
            return _books.OrderBy(b => b.Title);
        }

        public Book Get(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public Book Add(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
            return book;
        }

        List<Book> _books;


    }
};
