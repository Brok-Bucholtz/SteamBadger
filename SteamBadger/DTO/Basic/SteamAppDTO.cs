using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBadger.DTO.Basic {
    public class SteamAppDTO : Interface.AbstractDTO {
        public int appid { get; set; }
        public string name { get; set; }
        public string img_icon_url { get; set; }
        public string img_logo_url { get; set; }
        public bool has_community_visible_stats { get; set; }
    }
}