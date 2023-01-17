using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Aww_Api_Fetch
{
    public class ApiHandler
    {
        private HttpClient _client { get; set; }
        private HttpRequestMessage _search { get; set; }
        private HttpRequestMessage _details { get; set; }
        private string _url { get; set; }
        public ApiHandler()
        {
            _url = @"https://www.reddit.com/r/aww/.json";
            _client = new HttpClient();
            GetSearchMessage();
        }
        public Dictionary<string,string> SetUrl(string url)
        {
            _url = url;
            GetSearchMessage();
            return Orchestrate();
        }
        public Dictionary<string,string> Orchestrate()
        {
            GetSearchMessage();
            Console.WriteLine(_url);
            Task<JObject> result = ProcessRequestAsync(_client, _search);
            
            JObject json = result.Result;
            
            JToken jToken = json["data"]["children"];
            var jArray = jToken.Where(j => (string)j["data"]["post_hint"] == "image");

            Dictionary<string, string> titlesAndImages = jArray
                .ToDictionary(k => (string)k["data"]["title"], v => (string)v["data"]["url_overridden_by_dest"]);
            return titlesAndImages;
        }
        public void GetSearchMessage()
        {
            _search = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_url),
                Headers = {}
            };
        }
        public static async Task<JObject> ProcessRequestAsync(HttpClient client,HttpRequestMessage request)
        {
            
            client.DefaultRequestHeaders.Accept
                .Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            CancellationToken token = new CancellationToken(false);
            using (var response = await client.SendAsync(request, token))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                JObject result = JObject.Parse(body);
                return result ?? new();
            }
        }
    }
}