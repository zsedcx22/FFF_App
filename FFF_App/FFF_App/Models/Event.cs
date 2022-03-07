using System;
using System.Collections.Generic;
using System.Text;

namespace FFF_App.Models
{
    public class Event
    {
        public string EventName { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
