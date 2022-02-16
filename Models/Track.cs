using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }

    }
}
