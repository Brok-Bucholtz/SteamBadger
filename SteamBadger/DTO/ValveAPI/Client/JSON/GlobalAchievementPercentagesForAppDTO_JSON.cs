using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBadger.DTO.ValveAPI.Client.JSON {
    public class GlobalAchievementPercentagesForAppDTO_JSON : Interface.AbstractClientDTO_JSON
    {
        public class Achievement
        {
            public string name { get; set; }
            public double percent { get; set; }
        }
        public class Achievementpercentages
        {
            public List<Achievement> achievements { get; set; }
        }

        public Achievementpercentages achievementpercentages { get; set; }
    }
}