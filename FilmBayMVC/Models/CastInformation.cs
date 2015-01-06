using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmBayMVC.Models
{
    public class CastInformation
    {
        public List<string> writers { get; set; }
        public List<string> producers { get; set; }
        public List<string> composers { get; set; }

        public CastInformation(List<string> writers, List<string> producers, List<string> composers)
        {
            this.writers = writers;
            this.producers = producers;
            this.composers = composers;
        }
    }
}