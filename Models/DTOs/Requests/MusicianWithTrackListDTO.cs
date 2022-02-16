using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;

namespace WebApplication1.Models.DTOs.Requests
{
    public class MusicianWithTrackListDTO
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public LinkedList<Track> TrackList { get; set; }

    }
}
