using System;
using System.Collections.Generic;
using System.Text;

namespace FFF_App.Models
{
    public class Screening : Film
    {
        public string Cinema { get; set; }
        public DateTime ScreeningDateAndTime { get; set; }
    }
}
