 //Debug
using System;
using System.Diagnostics;

namespace SteamBadger.Models.SpecialProcessing {
    public class ErrorHandlerClass {
        public void HandleException(Exception exception) {
            string output = "Error Exception: " + exception.ToString();
            Console.WriteLine(output);
            Debug.WriteLine(output);
        }
    }
}