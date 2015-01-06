using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmBayMVC.Models
{
    public class FoundMovieDetails
    {
        public List<string> genres { get; set; }
        public string storyline { get; set; }

        public string studio { get; set; }
        public int duration { get; set; }
        public List<string> languages { get; set; }
        public string ageRestriction { get; set; }
        public FoundMovieDetails( List<string> genres, string storyline, int duration, List<string> languages ,string ageRestriction, string studio)
        {
            this.genres = genres;
            this.storyline = storyline;
            this.studio = studio;
            this.duration = duration;
            this.languages = languages;
            this.ageRestriction = ageRestriction;
        }
    }
}