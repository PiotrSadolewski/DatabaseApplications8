using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public class Musician_Track
    {
        public int IdTrack { get; set; }
        public virtual Track Track { get; set; }

        public int IdMusician { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
