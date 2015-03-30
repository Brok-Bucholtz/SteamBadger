using System;
using System.Collections.Generic;

namespace SteamBadger.Services
{
    public interface ISteamApiService
    {
        List<Models.SteamAPIDatabase.SteamApp> GetGamesAsyncByUserId(UInt64 userId);
    }
}