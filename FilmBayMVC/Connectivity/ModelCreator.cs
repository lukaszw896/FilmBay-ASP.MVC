using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmBayMVC.Models;
using System.Threading.Tasks;
namespace FilmBayMVC.Connectivity
{
    public static class ModelCreator
    {
        public async static Task<FilmPageModel> getFilmPageModel(int filmid)
        {
            film_table f = new film_table();
            f = await DBAccess.GetFilmById(filmid);
            List<writers_table> writers = await DBAccess.GetWriters(filmid);
            List<producer_table> producers = await DBAccess.GetProducers(filmid);
            List<music_creator_table> composers = await DBAccess.GetComposers(filmid);
            List<actor_table> actors = await DBAccess.GetActors(filmid);
            List<string> languages = await DBAccess.GetLanguages(filmid);
            List<string> genres = await DBAccess.GetGenres(filmid);

            FilmPageModel film = new FilmPageModel();
            film.Director = f.director_name + " " + f.director_surname;
            film.poster = f.poster_url;
            film.storyline = f.storyline;
            film.Title = f.title;
            film.rating = f.rating.ToString();
            film.duration = f.duration.ToString();
            film.Writers = new  List<string>();
            foreach (writers_table w in writers)
            {
                film.Writers.Add(w.ToString());
            }
            film.Producers = new List<string>();
            foreach (producer_table p in producers)
            {
                film.Producers.Add(p.ToString());
            }
            film.actors = actors;
            film.Composers = composers;
            film.ReleaseDate = f.release_date.ToString().Substring(0, 10);
            return film;

        }
    }
}