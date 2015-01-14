using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmBayMVC.Models;
using FilmBayMVC;
using System.Threading.Tasks;
using FilmBayMVC.Connectivity;

namespace FilmBayMVC.Controllers
{
    public class FilmPageController : Controller
    {
        // GET: FilmPage
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> FilmPage()
        {
            int id =6;

            FilmPageModel film = await ModelCreator.getFilmPageModel(id);
       

            return View(film);
        }
    }
}