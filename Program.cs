using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RavelryAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await HttpTestAsync();
            string x = await HttpTestAsync();
            JObject googleSearch = JObject.Parse(x);
            var resultsArray = googleSearch["fiber_attributes"];
            JEnumerable<JToken> results = resultsArray.Children();
            var attributes = new List<FiberAttribute>();
            foreach (var item in results)
            {
                FiberAttribute fiberAttribute = item.ToObject<FiberAttribute>();
                attributes.Add(fiberAttribute);
            }
        }

        static async Task<string> HttpTestAsync()
        {
            using var httpClient = new HttpClient();
            using var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.ravelry.com/fiber_attributes.json");
            var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("d42ac631b8d10a866ea40408e01cd5d3:GTb2bgU2OJuv1w_z0pxVSvYDLUU6f-v5kawXTs4-"));
            request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

            HttpResponseMessage response = await httpClient.SendAsync(request);
            string x = response.Content.ReadAsStringAsync().Result;
            return x;
        }
    }


    public class FiberAttribute
    {
        [JsonProperty("fiber_attribute_group_id")]
        public long FiberAttributeGroupId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }
    }
}
