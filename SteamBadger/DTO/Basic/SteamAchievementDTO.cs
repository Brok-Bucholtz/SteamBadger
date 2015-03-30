using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBadger.DTO.Basic
{
    public class SteamAchievementDTO : Interface.AbstractDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public string apiname { get; set; }
    }
}