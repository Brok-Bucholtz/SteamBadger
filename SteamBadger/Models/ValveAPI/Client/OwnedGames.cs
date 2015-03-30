using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using SteamBadger.DTO.ValveAPI.Client;

namespace SteamBadger.Models.ValveAPI.Client {
    public class OwnedGames  : Interface.AbstractClient {
        const string API_STRING = "IPlayerService/GetOwnedGames";
        const string API_VERSION = "0001";
        string steamID;

        public OwnedGames(UInt64 steamID) : this(steamID.ToString()) { }
        public OwnedGames(string steamID) : base() { 
            this.steamID = steamID;

            Mapper.CreateMap<DTO.ValveAPI.Client.JSON.OwnedGamesDTO_JSON.game, DTO.Basic.SteamAppDTO>()
                .ForMember(dest => dest.error, opt => opt.Ignore());

            Mapper.AssertConfigurationIsValid();
        }

        public List<DTO.Basic.SteamAppDTO> getDTO()
        {
            var parameters = new List<Tuple<string,string>>() {
                new Tuple<string,string>("key", STEAM_API_KEY),
                new Tuple<string,string>("steamid", steamID),
                new Tuple<string,string>("include_appinfo", "1"),
                new Tuple<string,string>("include_played_free_games", "1"),
                new Tuple<string,string>("format", FORMAT_JSON)};
            var response = getStringResponse(API_STRING, API_VERSION, parameters);

            if (response == null) { return null; }
            var responseJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.ValveAPI.Client.JSON.OwnedGamesDTO_JSON>(response);

            try {
                var steamApps = Mapper.Map<List<DTO.ValveAPI.Client.JSON.OwnedGamesDTO_JSON.game>, List<DTO.Basic.SteamAppDTO>>(responseJSON.response.games);
                return steamApps;
            } catch(Exception e) {
                ErrorHandler.HandleException(e);
            }
            return null;
        }
    }
}