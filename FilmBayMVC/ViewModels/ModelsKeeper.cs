using FilmBayMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmBayMVC.ViewModels
{
    public class ModelsKeeper
    {
        public List<MovieSearchReturnObjectViewModel> movieSearchReturnObjectViewModels;
        public film_table filmTable;
        public FilmPageModel filmPageModel;
        public List<film_table> filmTableList;
        public List<string> mainPageFilmPhotos;
        public List<string> generesList;
        public List <FilmToShow> filmsToShow;
        public string genre;
        public ModelsKeeper()
        {
            this.movieSearchReturnObjectViewModels = new List<MovieSearchReturnObjectViewModel>();
            this.filmTableList = new List<film_table>();
            this.mainPageFilmPhotos = new List<string>();
            this.generesList = new List<string>();
            this.filmsToShow = new List<FilmToShow>();
        }
    }
}