using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibraryWebApp.ViewModels;

namespace MyLibraryWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("/MyFavorites")]
        [HttpGet]
        public IActionResult MyFavorites()
        {
            var repo = new FavoritesRepository();
            var model = new FavoritesViewModel();

            model.FavoritesBigList = repo.GetAllFavorites();
            
            return  View(model);
        }


    }
}