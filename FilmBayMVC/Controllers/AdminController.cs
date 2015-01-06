using FilmBayMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FilmBayMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminPanel()
        {
            return View();
        }
       
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult SearchFilmResult(String filmName)
        {
            var list = new List<MovieSearchReturnObjectViewModel>();
            if (filmName != null)
            {


                List<MovieSearchReturnObject> tmpList = null;

                tmpList = TMDbApi.movieSearch(filmName);
                /*
                 * 
                 * DAŁEM SORTOWANIE POPULARNOŚCI ZA POMOCĄ BUBBLE SORTA. TRZEBA ZMIENIĆ!!!!!
                 * 
                 * */
                MovieSearchReturnObject tmp;
                for (int i = 0; i < tmpList.Count(); i++)
                {
                    for (int j = 0; j < tmpList.Count() - 1; j++)
                    {
                        if (tmpList[j].popularity < tmpList[j + 1].popularity)
                        {
                            tmp = tmpList[j];
                            tmpList[j] = tmpList[j + 1];
                            tmpList[j + 1] = tmp;
                        }
                    }

                }
                for (int i = 0; i < tmpList.Count(); i++)
                {
                    MovieSearchReturnObjectViewModel tmpModel = new MovieSearchReturnObjectViewModel();
                    tmpModel.id = tmpList[i].id;
                    tmpModel.orginalTitle = tmpList[i].orginalTitle;
                    tmpModel.popularity = tmpList[i].popularity;
                    tmpModel.posterPath = tmpList[i].posterPath;
                    tmpModel.releaseDate = tmpList[i].releaseDate;
                    tmpModel.title = tmpList[i].title;

                    list.Add(tmpModel);
                }

                return PartialView("_SearchResultPartial",list);
            }
            else
                return PartialView("_SearchResultPartial"); 
        }
    }
}