using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBadger.DTO.ValveAPI.Client.JSON {
    public class OwnedGamesDTO_JSON : Interface.AbstractClientDTO_JSON
    {
        public class game
        {
            public int appid { get; set; }
            public string name { get; set; }
            public string img_icon_url { get; set; }
            public string img_logo_url { get; set; }
            public bool has_community_visible_stats { get; set; }
            public int playtime_2weeks { get; set; }
            public int playtime_forever { get; set; }
        }
        public class Response {
            public int game_count { get; set; }
            public List<game> games { get; set; }
        }

        public Response response { get; set; }
    }
}