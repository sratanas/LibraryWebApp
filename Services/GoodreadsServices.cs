using MyLibraryWebApp.Goodreads;
using System.Threading.Tasks;

namespace MyLibraryWebApp.Services
{
    public class GoodreadsServices : IGoodreadsServices
    {
        private readonly IGetBookByTitle _getBookByTitle;

        public GoodreadsServices(IGetBookByTitle getBookByTitle)
        {
            _getBookByTitle = getBookByTitle;
        }

        public async Task<GoodreadsResponse> GetBookBasedOnTitleInput(string searchInput)
        {
            return await _getBookByTitle.ReturnBookBasedOnTitle(searchInput);
        }
    }
}
