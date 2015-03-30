using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SteamBadger.Models.SteamAPIDatabase {
    public class SteamApp {
        [Key]
        public int dbID { get; set; }
        public int valveID { get; set; }
        public string name { get; set; }
        public string img_icon_url { get; set; }
        public string img_logo_url { get; set; }
        public virtual ICollection<Achievement> Achievments { get; set; }
    }
}