using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmBayMVC.Models
{
    public class  FilmToShow 
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
          public List<string> Genres  {get; set;}
        public string poster { get; set; }
        public string rating { get; set; }
        public string Director { get; set; }
    }
}