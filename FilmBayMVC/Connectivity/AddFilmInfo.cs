using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmBayMVC;
using FilmBayMVC.Models;
using System.Threading.Tasks;
namespace FilmBayMVC.Connectivity
{
    public static  class AddFilmInfo
    {
        public async static Task FilmCreation(MovieSearchReturnObject Movie)
        {
             int FoundMovieid = Movie.id;
            FoundMovieDetails details = TMDbApi.movieDetails(FoundMovieid);
            List<actor_table> actors = TMDbApi.GetActors(FoundMovieid);
            CastInformation cast = TMDbApi.getCast(FoundMovieid);
            List<string> pictures = TMDbApi.getFilmPictures(FoundMovieid);

            List<writers_table> writers = new List<writers_table>();
            List<music_creator_table> composers = new List<music_creator_table>();
            List<producer_table> producers = new List<producer_table>();
            List<genere_table> genres = new List<genere_table>();


            string Day = Movie.releaseDate.Substring(9, 2);
            string Month = Movie.releaseDate.Substring(6, 2);
            string Year = Movie.releaseDate.Substring(1, 4);

            string Duration_H = (details.duration / 60).ToString();
            string Duration_M = (details.duration % 60).ToString();
            string Duration_S = "0";
            TimeSpan duration = TimeSpan.Parse(Duration_H + ":" + Duration_M + ":" + Duration_S);
          
            DateTime releasedate = System.DateTime.Parse(Month + "/" + Day + "/" + Year);

            

            int filmid;
            filmid = await DBAccess.CreateFilm("Gorge", "lukas", 10, details.studio, details.storyline, Movie.title, Movie.orginalTitle, "English", duration, Movie.posterPath
                , 16, details.studio, releasedate);


            foreach (string writer in cast.writers)
            {
                String[] split = writer.Split(' ');
                string name = split[0];
                string surname = "";
                if (split.Count() >= 2)
                    surname = split[1];
                writers_table tmpWriter = new writers_table() { writer_name = name, writer_surname = surname };
                writers.Add(tmpWriter);
            }
            /*
            foreach (string genre in details.genres)
            {
             

                int genreid = await DBAccess.CreateGenre(genre);
                film_genere_table g = DBAccess.CreateGenreFilmTable(filmid, genreid);

            }*/
            /*
            foreach (string language in details.genres)
            {

                int langid = await DBAccess.CreateLanguage(language);
                film_other_language_table l = DBAccess.CreateFilmLanguageTable(filmid, langid);

            }*/
            foreach (string composer in cast.composers)
            {
                String[] split = composer.Split(' ');
                string name = split[0];
                string surname = "";
                if (split.Count() >= 2)
                    surname = split[1];
                music_creator_table tmpComposer = new music_creator_table() { music_creator_name = name, music_creator_surname = surname };
                composers.Add(tmpComposer);
            }

            foreach (string producer in cast.producers)
            {
                String[] split = producer.Split(' ');
                string name = split[0];
                string surname = "";
                if (split.Count() >= 2)
                    surname = split[1];
                producer_table tmpProducer = new producer_table() { producer_name = name, producer_surname = surname };
                producers.Add(tmpProducer);
            }

            /* Adding photos to gallery  */

        List<int> photoIdTmpList = new List<int>();
            foreach (string path in pictures)
            {
                bool b = true;
                int photoid = await DBAccess.CreatePhoto(path);
                foreach (int id in photoIdTmpList)
                {
                    if (id == photoid) { b = false; break; }
                }
                if (b == true)
                {
                    photoIdTmpList.Add(photoid);
                    film_photos_table filmphoto = DBAccess.CreatePhotosFilmTable(filmid, photoid);

                }
            }
   
            List<int> actortmplist = new List<int>();
            foreach (actor_table a in actors)
            {
                bool b = true;
                int actorid = await DBAccess.CreateActor(a.actor_name, a.actor_surname, a.actor_photo_url);
                foreach (int id in actortmplist)
                {
                    if (id == actorid) { b = false; break; }
                }
                if (b == true)
                {

                    actortmplist.Add(actorid);
                    actor_film_table actorfilmtable = DBAccess.CreateActorFilmTable(filmid, actorid);

                }

            }

            foreach (writers_table w in writers)
            {

                int writerid = await DBAccess.CreateWriter(w.writer_name, w.writer_surname);

     film_writers_table filmwriterstable = DBAccess.CreateWriterFilmTable(filmid, writerid);

            }

            //adding composers to music_creator table and to reference connected table film_music_creator table
            foreach (music_creator_table c in composers)
            {
                int composerid = await DBAccess.CreateComposer(c.music_creator_name, c.music_creator_surname);
             film_music_creator filmcomposer = DBAccess.CreateComposerFilmTable(filmid, composerid);

            }


            //adding producers to the producers table.
            foreach (producer_table p in producers)
            {
                DBAccess.CreateProducer(p.producer_name, p.producer_surname, filmid);
            }


        }


    }
}