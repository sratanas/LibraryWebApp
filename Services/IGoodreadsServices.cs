using MyLibraryWebApp.Goodreads;
using System.Threading.Tasks;

namespace MyLibraryWebApp.Services
{
    public interface IGoodreadsServices
    {
        Task<GoodreadsResponse> GetBookBasedOnTitleInput(string searchInput);
    }
}
