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
    }
}