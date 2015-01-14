using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using FilmBayMVC.Models;
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
            List<FilmBayMVC.Models.film_table> myfilms = new  List<FilmBayMVC.Models.film_table>();
           myfilms = await DBAccess.GetAllFilms();



           List<FilmToShow> films = new List<FilmToShow>();
            foreach(film_table f in myfilms)
            {
                int filmid = f.id_film;
                List<string> genres = await DBAccess.GetGenres(filmid);
                FilmToShow x = new FilmToShow();
                x.Film = f;
                x.Genres = genres;
                films.Add(x);
            }
        

            

            return View(myfilms);
        }
     

    }
}