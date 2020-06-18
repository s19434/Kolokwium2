using System;
using System.Collections;
using System.Collections.Generic;

namespace KOLOS.Models
{
    public class Event
    {
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Event_Organiser> Event_Organisers { get; set; }
        public ICollection<Artist_Event> Artist_Events { get; set; }


    }
}