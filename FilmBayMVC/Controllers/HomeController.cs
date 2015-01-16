using FilmBayMVC.Models;
using FilmBayMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FilmBayMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ModelsKeeper modelsKeeper = new ModelsKeeper();
             List<film_table> filmTable = await DBAccess.GetAllFilms();
             List<string> photosUrl = new List<string>();
             List<string> generes = await DBAccess.getAllGeneres();
             for (int i = 0; i < filmTable.Count(); i++)
             {
                 for (int j = 0; j < filmTable.Count()-1; j++)
                 {

                     if (filmTable[j].rating==null)
                     {
                         film_table tmp = filmTable[j];
                         filmTable[j] = filmTable[j + 1];
                         filmTable[j + 1] = tmp;
                     }
                     else if (filmTable[j + 1].rating != null)
                     {
                        if( filmTable[j].rating < filmTable[j + 1].rating)
                        {
                            film_table tmp = filmTable[j];
                            filmTable[j] = filmTable[j + 1];
                            filmTable[j + 1] = tmp;
                        }
                     }
                 }
             }
             if (filmTable.Count > 5)
             {
                 for (int i = 0; i < 6; i++)
                 {
                     List<photos_table> Photos = await DBAccess.GetPhotos(filmTable[i].id_film);
                     photosUrl.Add(Photos[0].photo_url);
                 }
             }
                 modelsKeeper.mainPageFilmPhotos = photosUrl;
                 modelsKeeper.filmTableList = filmTable;
                 modelsKeeper.generesList = generes;
                 ViewBag.PageNumber = 0;
            return View(modelsKeeper);
        }
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult LoadPage(int id)
        {
            ViewBag.PageNumber = id;
            return PartialView("_filmsSortedByGenereAndRatingPartialView");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public async Task<ActionResult> SearchFilmResult(String filmName)
        {
            var list = new List<MovieSearchReturnObjectViewModel>();
            if (filmName != null)
            {


                List<MovieSearchReturnObject> tmpList = new List<MovieSearchReturnObject>();
               List< film_table> filmList = new List <film_table>();
               filmList = await DBAccess.SearchedByTitle(filmName);
                foreach(film_table f in filmList)
                {
                    MovieSearchReturnObject m = new MovieSearchReturnObject();
                    m.id = f.id_film;
                    m.title = f.title;
                    m.orginalTitle = f.title_orginal;
                    m.posterPath = f.poster_url;
                    m.releaseDate = f.release_date.ToString();
                    tmpList.Add(m);
                }
            //    tmpList = DBAccess.SearchedByTitle;
                //tmpList = TMDbApi.movieSearch(filmName);
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

                ModelsKeeper modelsKeeper = new ModelsKeeper() { movieSearchReturnObjectViewModels = list };
                
                return PartialView("_userMovieSearchPartial", modelsKeeper);
            }
            else
                return PartialView("_userMovieSearchPartial");
        }
    }
}