using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteamBadger.Models.SteamAPIDatabase;

namespace SteamBadger.Services
{
    public class SteamApiService : ISteamApiService
    {
        public List<Models.SteamAPIDatabase.SteamApp> GetGamesAsyncByUserId(UInt64 userId)
        {
            return new List<SteamApp>();
        }
    }
}