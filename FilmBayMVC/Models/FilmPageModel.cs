using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmBayMVC.Models;
namespace FilmBayMVC.Models
{
    public class FilmPageModel
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }

        public string storyline { get; set; }
        public string poster { get; set; }
        public string rating { get; set; }
        public string Director { get; set; }

        public string duration { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Writers { get; set; }

        public List<string> Producers { get; set; }

        public List<string> Languages { get; set; }

        public List<music_creator_table> Composers { get; set; }

        public List<actor_table> actors { get; set; }


    }
}