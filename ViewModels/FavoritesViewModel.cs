using MyLibrary.Data;
using System.Collections.Generic;

namespace MyLibraryWebApp.ViewModels
{
    public class FavoritesViewModel : IFavorites
    {
       public int Id { get; set; }
       public string Type { get; set; }
       public string Title { get; set; }
       public IEnumerable<Book> Favorites { get; set; }
    }
}
