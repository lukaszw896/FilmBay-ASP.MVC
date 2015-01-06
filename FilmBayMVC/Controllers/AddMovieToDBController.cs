using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmBayMVC.Models;
using System.Threading.Tasks;
using FilmBayMVC.Connectivity;

namespace FilmBayMVC.Controllers
{
    public class AddMovieToDBController : Controller
    {
        // GET: AddMovieToDB
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AddMovietoDB()
    {
       // int Foundmovieid = Movie.id;
        MovieSearchReturnObject sample = new MovieSearchReturnObject();
        sample.id = 15;
        sample.orginalTitle = "Dupa";
        sample.popularity = 15;
        sample.posterPath = "Wrong";
        sample.releaseDate = @"""1998-08-13""";
        sample.title = "Wladca pierdzieli";

        await AddFilmInfo.FilmCreation(sample);

                return View(sample);
        }

    
    }
    }
