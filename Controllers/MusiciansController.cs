using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.models;
using WebApplication1.Models.DTOs.Requests;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly MDbContext _context;
        public MusiciansController(MDbContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")]
        public IActionResult GetMusicians(int Id) 
        {
            Musician tmpMusician = _context.Musicians.Where(m => m.IdMusician == Id).FirstOrDefault();
    /*        var newTrackList = _context.Musician_Tracks.Join(_context.Tracks, mt => mt.IdTrack, t => t.IdTrack, (MT, T) => new {
                T.IdTrack, T.TrackName
            }).Where(e => e.);*/

            MusicianWithTrackListDTO Musician = new MusicianWithTrackListDTO {
                FirstName = tmpMusician.FirstName,
                LastName = tmpMusician.LastName,
                NickName = tmpMusician.NickName,
    /*            TrackList = newTrackList;*/
            };
            return Ok(Musician);
        }

        [HttpPost]
        public IActionResult AddMusician(Musician musician) 
        {
            _context.Musicians.Add(musician);
            _context.SaveChanges();
            return Ok("Musician has been added");
        }
    }
}
