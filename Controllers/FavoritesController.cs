using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibraryWebApp.ViewModels;
using System.Collections.Generic;

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


            model.TupleList = repo.GetAllFavorites();


            return  View(model);
        }

        
        //public IActionResult AddToFavorites(IFavorites favorite)
        //{
        //    FavoritesRepository.AddToFavorites(favorite);

        //   return 
        //}

    }
}