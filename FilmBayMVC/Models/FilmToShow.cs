using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmBayMVC.Models
{
    public class FilmToShow
    {
        public FilmBayMVC.Models.film_table Film;
        public List<string> Genres  {get; set;}
    }
}