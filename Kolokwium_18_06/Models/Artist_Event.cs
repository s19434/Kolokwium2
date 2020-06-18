using System;

namespace KOLOS.Models
{
    public class Artist_Event
    {
        public int IdEvent { get; set; }
        public int IdArtist { get; set; }
        public DateTime PerfomanceDate { get; set; }


        public Event Event { get; set; }
        public Artist Artist { get; set; }

    }
}