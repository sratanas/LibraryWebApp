using System.Threading.Tasks;

namespace MyLibraryWebApp.Goodreads
{
    public interface IGetBookByTitle
    {
        Task<GoodreadsResponse> ReturnBookBasedOnTitle(string searchInput);
    }
}
