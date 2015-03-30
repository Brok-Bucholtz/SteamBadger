using System;
using System.Web.Mvc;
using SteamBadger.Services;

namespace SteamBadger.Controllers
{
    public class DefaultController : Controller
    {
        private ISteamApiService _steamApiService;

        public DefaultController(ISteamApiService steamApiService)
        {
            _steamApiService = steamApiService;
        }

        public ActionResult Index()
        {

            const UInt64 STEAM_ID = 0000000000000000000;    //Steam Id
            var testModel = new Models.ValveAPI.ValveAPIMain();

            var testData = testModel.getUserGamesAsync(STEAM_ID);
            return View();
        }
    }
}
