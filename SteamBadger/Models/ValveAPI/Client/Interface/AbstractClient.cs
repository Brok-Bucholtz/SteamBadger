using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using SteamBadger.Models.SpecialProcessing;

namespace SteamBadger.Models.ValveAPI.Client.Interface {
    using paramType = List<Tuple<string, string>>;

    public abstract class AbstractClient {
        protected const string STEAM_API_KEY = "XXXXXXXXXXXXXXXXXXXXXXXX";  //Steam Api Key

        //API
        protected const string FORMAT_JSON = "json";

        //WEB
        protected const string STEAM_API_DOMAIN = "api.steampowered.com";
        protected const string STEAM_PROTOCOL = "http";

        protected WebClient webClient = new WebClient();
        protected ErrorHandlerClass ErrorHandler = new ErrorHandlerClass();

        public AbstractClient() {
            //webClient.Headers["Content-Type"] = "application/json;charset=UTF-8";
            webClient.Headers.Add("Accept-Language", " en-US");
            webClient.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            webClient.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
                   
            return;
        }

        protected string parametersToString(paramType ListParameters) {
            if (ListParameters.Count > 0) {
                var firstElement = ListParameters.ElementAt(0);
                var stringParameters = "?" + firstElement.Item1 + "=" + firstElement.Item2;

                ListParameters.RemoveAt(0);
                foreach (var parameter in ListParameters) {
                    stringParameters += "&" + parameter.Item1 + "=" + parameter.Item2;
                }

                return stringParameters;
            }
            return "";
        }
        protected string getStringResponse(string appString, string apiVersion, paramType parameters) {
            string steamAPIURL = STEAM_PROTOCOL + "://" + STEAM_API_DOMAIN + "/" + appString + "/v" + apiVersion + "/";
            string steamAPIURL_parameters = parametersToString(parameters);

            try {
                string jsonString = webClient.DownloadString(steamAPIURL + steamAPIURL_parameters);
                return jsonString;
            } catch(WebException webE) {
                if(webE.Status == WebExceptionStatus.ProtocolError) {
                    var httpResponse = webE.Response as HttpWebResponse;
                    if(httpResponse.StatusCode == HttpStatusCode.BadRequest) {
                        string responseString;

                        using(var reader = new System.IO.StreamReader(httpResponse.GetResponseStream())) {
                            responseString = reader.ReadToEnd();
                        }

                        return responseString;
                    }
                }

                ErrorHandler.HandleException(webE);
            }

            return null;
        }
        //public abstract DTO getDTO();
        //TODO: Implement Testing to make sure children create member function
    }
}