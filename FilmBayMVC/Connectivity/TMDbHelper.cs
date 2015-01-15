using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilmBayMVC
{
    class TMDbHelper
    {
        public static List<string> FindString(String start, String end, String input)
        {
            var results = new List<string>();

            string pattern = string.Format(
                "{0}({1}){2}",
                Regex.Escape(start),
                ".+?",
                 Regex.Escape(end));

            foreach (Match m in Regex.Matches(input, pattern))
            {
                results.Add(m.Groups[1].Value); 
                Console.WriteLine(m.Groups[1].Value);
            }
            return results;
        }
     
        public static string FindSingleString(String start, String end, String input)
        {
            List<string> results = new List<string>();

            string pattern = string.Format(
                "{0}({1}){2}",
                Regex.Escape(start),
                ".+?",
                 Regex.Escape(end));

            foreach (Match m in Regex.Matches(input, pattern))
            {
                results.Add(m.Groups[1].Value);
                Console.WriteLine(m.Groups[1].Value);
            }
            return results.FirstOrDefault();
        }
        public static List<string> FindStringWithOneUknownWord(String start,String middle, String end, String input)
        {
            var results = new List<string>();

            string pattern = string.Format(
                "{0}{1}{2}({3}){4}",
                Regex.Escape(start),
                "[0-9a-zA-Z]{1,20}",
                Regex.Escape(middle),
                ".+?",
                 Regex.Escape(end));

            foreach (Match m in Regex.Matches(input, pattern))
            {
                results.Add(m.Groups[1].Value);
                Console.WriteLine(m.Groups[1].Value);
            }
            return results;
        }


    }
  

    /*
    public class Actor
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string photoPath { get; set; }
    }

    public class Writer
    {
        public string WName { get; set; }
        public string WSurname { get; set; }
    }
    public class Producer
    {
        public string PName { get; set; }
        public string PSurname { get; set; }
    }

    public class Composer
    {
        public string CName { get; set; }
        public string CSurname { get; set; }
    }
    public class ALanguage
    {
        public string LName { get; set; }
    }
    public class Genre
    {
        public string GName { get; set; }
    }

      */

}
