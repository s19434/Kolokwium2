using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KOLOS.DTOs.Requests;
using KOLOS.Exceptions;
using KOLOS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KOLOS.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private IArtistsDbService _dbService;

        public ArtistsController(IArtistsDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetArtist(int id)
        {
            try
            {
                var result = _dbService.GetArtist(id);
                return Ok(result);
            }
            catch (ArtistDoesNotExistException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("{api/artists/id:int/events}")]
        public IActionResult UpdateScore(Events events)
        {
            try
            {
                _dbService.UpdateTimeEvent(events);
                return Ok("Time Updated");
            }
            catch (EventOrArtistDoesNotExistException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}