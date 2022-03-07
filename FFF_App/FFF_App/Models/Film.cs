using System;
using System.Collections.Generic;
using System.Text;

namespace FFF_App.Models
{
    public class Film
    {
        public string FilmNameEnglish { get; set; }
        public string FilmNameFrench { get; set; }
        public string Section { get; set; }
        public List<string> Cast { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public int RunningTime { get; set; }
        public string Synopsis { get; set; }
        public string Quote { get; set; }
        public bool HasQAndA { get; set; }
        //public List<string> Images { get; set; }
    }
}
