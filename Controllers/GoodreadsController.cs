using Microsoft.AspNetCore.Mvc;
using MyLibraryWebApp.Goodreads;
using MyLibraryWebApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace MyLibraryWebApp.Controllers
{
    public class GoodreadsController : Controller
    {
        private readonly IGoodreadsServices _goodreadsServices;

        public GoodreadsController(IGoodreadsServices goodreadsServices)
        {
            _goodreadsServices = goodreadsServices;
        }





        [HttpGet]
        [Route("goodreads/{searchInput}")]
        public async Task<IActionResult> GetBookInfo(string searchInput)
        {
            var result = await _goodreadsServices.GetBookBasedOnTitleInput(searchInput);



            return Ok(result);
        }

    }
}