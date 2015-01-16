using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmBayMVC.Models;
using FilmBayMVC;
using System.Threading.Tasks;
using FilmBayMVC.ViewModels;
using FilmBayMVC.Connectivity;
using Microsoft.AspNet.Identity;

namespace FilmBayMVC.Controllers
{
    public class FilmPageController : Controller
    {
        // GET: FilmPage
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> FilmPage(int id)
        {
            

            FilmPageModel film = await ModelCreator.getFilmPageModel(id);
    
            ModelsKeeper modelsKeeper = new ModelsKeeper() { filmPageModel = film };
            return View(modelsKeeper);
        }
        public async Task <ActionResult> Vote ( int number, int filmid)
        
        {
          //  string userid = User.Identity.GetUserId().ToString();
            string userid = "32d24310-3ed4-4dda-988d-1cffe134de9a";

        //    int id = 18;
           int voteforfilmresult= await DBAccess.VoteForFilm(filmid, userid, number);
           DBAccess.vote(number, filmid, voteforfilmresult);
           FilmPageModel film = await ModelCreator.getFilmPageModel(filmid);

            return View("FilmPage", film);
        }
        public async Task<ActionResult> Comment(string comment, int filmid)
        {
              FilmPageModel film = await ModelCreator.getFilmPageModel(filmid);
            string userid = User.Identity.GetUserId().ToString();
           // string username = User.Identity.Name.ToString();

            MyLINQDataContext con = new MyLINQDataContext();
            comment_table ct = new comment_table();
      
            ct.id_film = filmid;
            ct.id= userid;

            bool Alreadycommented = (con.comment_tables.AsParallel().Where(s => s.id_film == filmid && s.id == userid).Count()) > 0;
           
                if (Alreadycommented == true)
                {
                    ct.comment = comment;
                    DBAccess.UpdateComment(ct);
                    con.Dispose();
                }
                else
                {
                    ct.comment = comment;
                    DBAccess.AddComment(ct);

                    con.Dispose();
                }
                con.Dispose();
                 
            return View("FilmPage", film);
        }
    }
}