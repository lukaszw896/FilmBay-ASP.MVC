using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using FilmBayMVC.Models;
using FilmBayMVC.ViewModels;
using FilmBayMVC.Connectivity;
namespace FilmBayMVC.Controllers
{
    public class UserPageController : Controller
    {
        // GET: UserPage
        public ActionResult Index()
        {
         
            return View();
        }

        public async Task<ActionResult> UserInfo()
        {
            string id = User.Identity.GetUserId().ToString();
           List< FilmToShow> films = await ModelCreator.getFilmsToShow(id);
           ModelsKeeper modelsKeeper = new ModelsKeeper() { filmsToShow = films};
            return View(modelsKeeper);
        }
     

    }
}