using System.ComponentModel.DataAnnotations;

namespace FilmBayMVC.Models
{
    public class MovieSearchReturnObjectViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string releaseDate { get; set; }
        public string posterPath { get; set; }
        public string orginalTitle { get; set; }
        public float popularity { get; set; }
    }
}