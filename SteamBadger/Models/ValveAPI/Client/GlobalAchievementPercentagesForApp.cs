using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using SteamBadger.DTO.ValveAPI.Client;

namespace SteamBadger.Models.ValveAPI.Client {
    public class GlobalAchievementPercentagesForApp : Interface.AbstractClient {
        const string API_STRING = "ISteamUserStats/GetGlobalAchievementPercentagesForApp";
        const string API_VERSION = "0002";
        string appID;

        public GlobalAchievementPercentagesForApp(int appID) : this(appID.ToString()) { }

        public GlobalAchievementPercentagesForApp(string appID) : base() {
            this.appID = appID;
                
            var mapGlobalAchievementPercentagesForAppDTO_JSON_TO_TupleSteamAchievementDTO =
                Mapper.CreateMap<DTO.ValveAPI.Client.JSON.GlobalAchievementPercentagesForAppDTO_JSON.Achievement,Tuple<DTO.Basic.SteamAchievementDTO, double>>();
            mapGlobalAchievementPercentagesForAppDTO_JSON_TO_TupleSteamAchievementDTO.ForAllMembers(opt => opt.Ignore());

            Mapper.AssertConfigurationIsValid();
        }

        public List<Tuple<DTO.Basic.SteamAchievementDTO, double>> getDTO() {
            var parameters = new List<Tuple<string,string>>() {
                new Tuple<string,string>("gameid", appID),
                new Tuple<string,string>("format", FORMAT_JSON)};
            var response = getStringResponse(API_STRING, API_VERSION, parameters);

            if (response == null) { return null; }
            var responseJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.ValveAPI.Client.JSON.GlobalAchievementPercentagesForAppDTO_JSON>(response);
            
            try {
                var globalAchievments = Mapper.Map<List<DTO.ValveAPI.Client.JSON.GlobalAchievementPercentagesForAppDTO_JSON.Achievement>, List<Tuple<DTO.Basic.SteamAchievementDTO, double>>>(responseJSON.achievementpercentages.achievements);
                return globalAchievments;
            } catch(Exception e) {
                ErrorHandler.HandleException(e);
            }

            return null;
        }
    }
}