using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmBayMVC.Models;
using FilmBayMVC;
using System.Threading.Tasks;
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
            film_table f = new film_table();

            f = await DBAccess.GetFilmById(id);
            List<writers_table> writers = await DBAccess.GetWriters(id);
            List<producer_table> producers = await DBAccess.GetProducers(id);
            List<music_creator_table> composers = await DBAccess.GetComposers(id);
            List<actor_table> actors = await DBAccess.GetActors(id);
            List<string> languages = await DBAccess.GetLanguages(id);
            List<string> genres = await DBAccess.GetGenres(id);

            FilmPageModel film = new FilmPageModel();
            film.Director = f.director_name + "" + f.director_surname;
            film.poster = f.poster_url;
            film.storyline = f.storyline;
            film.Title = f.title;
            film.rating = f.rating.ToString();
            film.duration = f.duration.ToString();
            
            foreach(writers_table w in writers)
            {
                film.Writers.Add(w.ToString());
            }
            foreach (producer_table p in producers)
            {
                film.Producers.Add(p.ToString());
            }
            film.actors = actors;
            film.Composers = composers;
            film.ReleaseDate = f.release_date.ToString().Substring(0, 10);

            return View(film);
        }
    }
}