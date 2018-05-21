using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyLibraryWebApp.ViewModels
{
    public class FavoritesViewModel : IFavorites
    {
       public int Id { get; set; }
       public string Type { get; set; }
       public string Title { get; set; }
       public Book Book { get; set; }
       public List<List<IFavorites>> FavoritesBigList { get; set; }
       public List<Author> FavoriteAuthors { get; set; }
       public Tuple<List<Book>, List<Author>, List<AudioBook>> TupleList { get; set; }
      
    }


}
