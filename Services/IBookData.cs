using MyLibrary.Data;
using System.Collections.Generic;

namespace MyLibraryWebApp.Services
{
    public interface IBookData
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);
        Book Add(Book book);
    }
}
