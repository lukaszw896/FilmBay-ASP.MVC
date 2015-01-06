using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmBayMVC.Models
{
    public class MovieSearchReturnObject
    {
        public int id { get; set; }
        public string title { get; set; }
        public string releaseDate { get; set; }
        public string posterPath { get; set; }
        public string orginalTitle { get; set; }
        public float popularity { get; set; }
          public MovieSearchReturnObject()
        { }
        public MovieSearchReturnObject(int id, string title, string releaseDate, string posterPath, string orginalTitle, float popularity)
        {
            this.id = id;
            this.title = title;
            this.releaseDate = releaseDate;
            this.posterPath = posterPath;
            this.orginalTitle = orginalTitle;
            this.popularity = popularity;
        }

    }
}