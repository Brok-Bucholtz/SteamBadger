using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBadger.DTO.Interface
{
    public abstract class AbstractDTO
    {
        public SpecialProcessing.ErrorDTO error { get; set; }
    }
}