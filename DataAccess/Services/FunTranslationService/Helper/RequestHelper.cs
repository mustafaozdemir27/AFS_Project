using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DataAccess.Services.FunTranslationService.Helper
{
    public static class RequestHelper
    {
        private static string baseURL = WebConfigurationManager.AppSettings["FunTranslationsApiURL"];
        public static T RequestClient<T>(Method method, string requestUrl, dynamic requestBody)
        {
            try
            {
                if (requestBody != null)
                {
                    RestClient client = new RestClient(baseURL);
                    RestRequest request = new RestRequest(requestUrl, method, DataFormat.Json) { Timeout = 50000 };
                    request.AddHeader("Content-Type", "application/json");
                    request.AddJsonBody(JsonConvert.SerializeObject(requestBody));

                    IRestResponse response = client.Execute(request);

                    if ((response != null) && (response.StatusCode == HttpStatusCode.OK))
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content);
                    }
                    return default(T);
                }
                throw new ArgumentNullException(nameof(requestBody));
            }
            catch
            {
                // TODO : Throw Process
                return default(T);

            }
        }
    }
}

