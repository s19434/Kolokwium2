using KOLOS.DTOs.Requests;
using KOLOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLOS.Services
{
    public interface IArtistsDbService
    {
        Artist GetArtist(int id);
        void UpdateTimeEvent(Events events );

    }
}
