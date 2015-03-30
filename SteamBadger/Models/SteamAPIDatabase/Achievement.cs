using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SteamBadger.Models.SteamAPIDatabase {
    public class Achievement {
        [Key]
        public string name { get; set; }
        public double globalPercentAchieved { get; set; }
        public string description { get; set; }
        public string apiname { get; set; }
        [Key]
        public virtual SteamApp SteamApp { get; set; }
    }
}