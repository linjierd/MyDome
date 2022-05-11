using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SMSSendService.Common
{
    public class HttpClientSample
    {
        private readonly ILogger log = Log.Logger;
        public string _api { get; set; }

        public HttpClientSample(string api)
        {
            _api = api;
        }

        public string Client(string verbs, string uri, Object obj = null)
        {
            string json = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Task<HttpResponseMessage> task = null;
                    //client.BaseAddress = new Uri($"{_api}/{uri}");
                    if (verbs.Equals("get")) task = client.GetAsync($"{_api}/{uri}");
                    if (verbs.Equals("post")) task = client.PostAsJsonAsync($"{_api}/{uri}", obj);
                    task.Wait();
                    HttpResponseMessage response = task.Result;
                    if (response.IsSuccessStatusCode) json = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return json;

        }
    }
}
