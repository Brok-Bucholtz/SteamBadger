using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBadger.DTO.Other {
    public class getTopUnfinishedAchievmentsDTO : Interface.AbstractDTO {
        //TODO: SteamApp will have duplicate data, find a better solution
        public class SteamApp {
            public int ID;
            public string name;
        }

        public class Achievement {
            public string description;
            public string image;
            public string name;
            public double percentAchieved;
            public SteamApp steamApp;
        }

        public List<Achievement> achievments;
    }
}