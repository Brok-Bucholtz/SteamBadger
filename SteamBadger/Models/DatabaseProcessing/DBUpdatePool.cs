using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBadger.Models.DatabaseProcessing
{
    public static class DBUpdatePool
    {
        private static System.Threading.WaitCallback wCallBack = o => {
            var data = (SteamAPIDatabase.SteamAPIDatabaseContext)o;
            data.SaveChanges();
        };

        public static void add(SteamAPIDatabase.SteamAPIDatabaseContext dbContext) {
            if(!System.Threading.ThreadPool.QueueUserWorkItem(wCallBack, dbContext)) { (new Models.SpecialProcessing.ErrorHandlerClass()).HandleException(new Exception("QueueUserWorkItem Returned False")); }
        }
    }
}