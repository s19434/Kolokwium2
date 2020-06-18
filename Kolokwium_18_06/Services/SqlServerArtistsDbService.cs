using KOLOS.DTOs.Requests;
using KOLOS.Exceptions;
using KOLOS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KOLOS.Services
{
    public class SqlServerArtistsDbService : IArtistsDbService
    {
        private ArtistsDbContext _context;

        public SqlServerArtistsDbService(ArtistsDbContext context)
        {
            _context = context;
        }

        public Artist GetArtist(int id)
        {
            var player = _context.Artists
                .Include(m => m.Artist_Events)
                .FirstOrDefault(m => m.IdArtist == id);

            if (player == null)
            {
                throw new ArtistDoesNotExistException($"Artist does not exist with id={id}");
            }
            player.Artist_Events = player.Artist_Events.OrderByDescending(p => p.PerfomanceDate).ToList();

            return player;
        }

        public void UpdateTimeEvent(Events events)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                var ev = _context.Artist_Events
                .Include(m => m.Artist)
                .Where(m => m.IdEvent == events.IdArtist)
                .Where(m1 => m1.IdEvent == events.IdEvent);


                if (ev == null)
                {
                    tran.Rollback();
                    throw new EventOrArtistDoesNotExistException($"Event does not exist with id={events.IdEvent} or artist does not exist with id={events.IdArtist} ");

                }


              //  ev.PerfomanceDate = events.PerfomanceDate;
                _context.SaveChanges();
                tran.Commit();


            }
        }
    }
}
