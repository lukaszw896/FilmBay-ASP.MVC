using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmBayMVC.Models;
using FilmBayMVC;
using System.Threading.Tasks;
using FilmBayMVC.ViewModels;
using FilmBayMVC.Connectivity;
using Microsoft.AspNet.Identity;

namespace FilmBayMVC.Controllers
{
    public class FilmPageController : Controller
    {
        // GET: FilmPage
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> FilmPage(int id)
        {
          
            FilmPageModel film = await ModelCreator.getFilmPageModel(id);
          
            ModelsKeeper modelsKeeper = new ModelsKeeper() { filmPageModel = film };

            return View(modelsKeeper);
            
    
        }
        public async Task <ActionResult> Vote ( int number, int filmid)
        
        {
           string userid = User.Identity.GetUserId().ToString();
   
           int voteforfilmresult= await DBAccess.VoteForFilm(filmid, userid, number);
           DBAccess.vote(number, filmid, voteforfilmresult);
           FilmPageModel film = await ModelCreator.getFilmPageModel(filmid);

            return View("FilmPage", film);
        }
        public async Task<ActionResult> Buy(int filmid)
        {
            string userid = User.Identity.GetUserId().ToString();

                   await DBAccess.BuyFilm(filmid, userid);

            FilmPageModel film = await ModelCreator.getFilmPageModel(filmid);
            return View("FilmPage", film);
        }
        /*
        public async Task<ActionResult> Edit()
        {
            int id = 26;
            FilmPageModel film = await ModelCreator.getFilmPageModel(id);

            ModelsKeeper modelsKeeper = new ModelsKeeper() { filmPageModel = film };

            return View("EditFilm", modelsKeeper);
        }*/



        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public async Task<ActionResult> Comment(string comment, int filmid)
        {
              FilmPageModel film = await ModelCreator.getFilmPageModel(filmid);
            string userid = User.Identity.GetUserId().ToString();
             await DBAccess.Commenting(filmid, userid, comment);
           return PartialView("_PartialComments", film);
           // return View("FilmPage", film);
        }
    }

}