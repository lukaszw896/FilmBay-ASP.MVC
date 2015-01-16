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
        public ModelsKeeper()
        {
            this.movieSearchReturnObjectViewModels = new List<MovieSearchReturnObjectViewModel>();
            this.filmTableList = new List<film_table>();
            this.mainPageFilmPhotos = new List<string>();
        }
    }
}