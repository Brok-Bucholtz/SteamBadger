using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBadger.DTO.ValveAPI.Client
{
    public class GlobalAchievementPercentagesForAppGetDTO
    {
        public DTO.Basic.SteamAchievementDTO achievment { get; set; }
        public double globalPercentAchieved;
    }
}