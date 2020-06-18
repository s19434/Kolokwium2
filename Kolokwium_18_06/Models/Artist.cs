using System;
using System.Collections;
using System.Collections.Generic;

namespace KOLOS.Models
{
    public class Artist
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }

        public ICollection<Artist_Event> Artist_Events { get; set; }
    }
}