using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBadger.DTO.SpecialProcessing
{
    public class ErrorDTO
    {
        public Exception exception { get; set; }
        public ErrorDTO(Exception e) { exception = e; }
    }
}