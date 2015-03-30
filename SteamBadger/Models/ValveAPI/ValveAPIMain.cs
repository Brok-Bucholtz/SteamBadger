using System;
using System.Collections.Generic;
using System.Linq;
using SteamBadger.Models.SpecialProcessing;
using System.Threading.Tasks;
using AutoMapper;

namespace SteamBadger.Models.ValveAPI {
    public class ValveAPIMain {
        ErrorHandlerClass ErrorHandler = new ErrorHandlerClass();

        const int TASK_GET_GAMES_MILISEC_TIMEOUT = 2000;
        public List<SteamAPIDatabase.SteamApp> getUserGamesAsync(UInt64 userID) {
            var owndedGamesDTO = (new Client.OwnedGames(userID)).getDTO();
            var getGameTasks = new List<Task<SteamAPIDatabase.SteamApp>>();
            var dbSteamAppList = new List<SteamAPIDatabase.SteamApp>();

            if(owndedGamesDTO == null) { return null; }

            foreach(var game in owndedGamesDTO) {
                getGameTasks.Add(getGameAsync(game));
                if(getGameTasks.Count > 1) { break; }    //TODO: For Testing, REMOVE
            }

            foreach(var task in getGameTasks) {
                if(task.Wait(TASK_GET_GAMES_MILISEC_TIMEOUT)){
                    var taskResult = task.Result;
                    if(taskResult != null) { dbSteamAppList.Add(taskResult); }
                } else { ErrorHandler.HandleException(new Exception("Task Timed Out")); }
            }

            return dbSteamAppList;
        }

        private Task<SteamAPIDatabase.SteamApp> getGameAsync(DTO.Basic.SteamAppDTO game) {
            var dbContextModel = new SteamAPIDatabase.SteamAPIDatabaseContext();
            var dbSteamApp = dbContextModel.SteamApps.SingleOrDefault(o => o.valveID == game.appid);

            if(dbSteamApp == null) {
                var clientGameAchievmentsDTO = (new Client.GlobalAchievementPercentagesForApp(game.appid)).getDTO();
                var dbSteamAchievments = new List<SteamAPIDatabase.Achievement>();

                if(clientGameAchievmentsDTO == null) { return Task.FromResult<SteamAPIDatabase.SteamApp>(null); }

                dbSteamApp = new SteamAPIDatabase.SteamApp();
                dbSteamApp.valveID = game.appid;
                dbSteamApp.name = game.name;
                dbSteamApp.img_icon_url = game.img_icon_url;
                dbSteamApp.img_logo_url = game.img_logo_url;
                try {
                    dbSteamApp.Achievments = Mapper.Map<List<SteamAPIDatabase.Achievement>>(clientGameAchievmentsDTO);
                } catch(Exception e) {
                    ErrorHandler.HandleException(e);
                    return Task.FromResult<SteamAPIDatabase.SteamApp>(null);
                }

                addToDBUpdateQueue(dbSteamApp);
            }

            return Task.FromResult(dbSteamApp);
        }

        private void addToDBUpdateQueue(SteamAPIDatabase.SteamApp dbSteamApp) {
            var dbContextModel = new SteamAPIDatabase.SteamAPIDatabaseContext();

            dbContextModel.SteamApps.Add(dbSteamApp);
            Models.DatabaseProcessing.DBUpdatePool.add(dbContextModel);
        }
    }
}