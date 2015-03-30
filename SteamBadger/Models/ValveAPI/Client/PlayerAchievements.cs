using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using SteamBadger.DTO.ValveAPI.Client;

namespace SteamBadger.Models.ValveAPI.Client {
    public class PlayerAchievements : Interface.AbstractClient {
        const string API_STRING = "ISteamUserStats/GetPlayerAchievements";
        const string API_VERSION = "0001";
        string appID;
        string steamID;

        public PlayerAchievements(int appID, UInt64 steamID) : this(appID.ToString(), steamID.ToString()) { }
        public PlayerAchievements(string appID, string steamID) : base() { 
            this.appID = appID; this.steamID = steamID;
            var mapPlayerAchievementsDTO_JSONAchievement_TO_TupleSteamAchievementDTO = Mapper.CreateMap<DTO.ValveAPI.Client.JSON.PlayerAchievementsDTO_JSON.Achievement, Tuple<DTO.Basic.SteamAchievementDTO, bool>>();
            mapPlayerAchievementsDTO_JSONAchievement_TO_TupleSteamAchievementDTO.ForAllMembers(opt => opt.Ignore());
            mapPlayerAchievementsDTO_JSONAchievement_TO_TupleSteamAchievementDTO
                .ForMember(dest => dest.Item1.apiname, opt => opt.MapFrom(source => source.apiname))
                .ForMember(dest => dest.Item1.name, opt => opt.MapFrom(source => source.name))
                .ForMember(dest => dest.Item1.description, opt => opt.MapFrom(source => source.description))
                .ForMember(dest => dest.Item2, opt => opt.MapFrom(source => source.achieved != 0));

            Mapper.AssertConfigurationIsValid();
        }

        public List<Tuple<DTO.Basic.SteamAchievementDTO, bool>> getDTO() {
            var parameters = new List<Tuple<string,string>>() {
                new Tuple<string,string>("appid", appID),
                new Tuple<string,string>("key", STEAM_API_KEY),
                new Tuple<string,string>("steamid", steamID),
                new Tuple<string,string>("L", "english"),
                new Tuple<string,string>("format", FORMAT_JSON)};
            var response = getStringResponse(API_STRING, API_VERSION, parameters);

            if (response == null) { return null; }
            var responseJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.ValveAPI.Client.JSON.PlayerAchievementsDTO_JSON>(response);

            try {
                var playerAchievments = Mapper.Map<List<DTO.ValveAPI.Client.JSON.PlayerAchievementsDTO_JSON.Achievement>, List<Tuple<DTO.Basic.SteamAchievementDTO, bool>>>(responseJSON.playerstats.achievements);
                return playerAchievments;
            } catch(Exception e) {
                ErrorHandler.HandleException(e);
            }

            return null;
        }
    }
}