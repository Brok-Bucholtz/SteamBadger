using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBadger.DTO.ValveAPI
{
    public class ValveMainAPIMainGetAppDTO : Interface.AbstractDTO
    {
        public int ID { get; set; }
        public string name { get; set; }
    }
}