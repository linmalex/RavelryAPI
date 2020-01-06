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
            string endpoint = "fiber_attributes";
            RavelryRequest ravRequest = new RavelryRequest();
            string requestResultString = await ravRequest.GetRequest(endpoint);

            List<FiberAttribute> x = await ravRequest.ParseToFiberAttributesAsync();

        }


    }
    public class RavelryRequest
    {
        readonly string baseUrl = "https://api.ravelry.com/";
        readonly string privateUsername = "d42ac631b8d10a866ea40408e01cd5d3";
        readonly string privatePassword = "GTb2bgU2OJuv1w_z0pxVSvYDLUU6f-v5kawXTs4-";

        public async Task<string> GetRequest(string endpoint)
        {
            using var httpClient = new HttpClient();
            string requestURI = baseUrl + endpoint + ".json";
            using var request = new HttpRequestMessage(new HttpMethod("GET"), requestURI);
            var creds = String.Format("{0}:{1}", privateUsername, privatePassword);
            var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(creds));
            request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

            HttpResponseMessage response = await httpClient.SendAsync(request);
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<List<FiberAttribute>> ParseToFiberAttributesAsync()
        {
            string endpoint = "fiber_attributes";
            string requestResultString = await GetRequest(endpoint);

            var attributes = new List<FiberAttribute>();
            JEnumerable<JToken> results = JObject.Parse(requestResultString)[endpoint].Children();

            foreach (var item in results)
            {
                FiberAttribute fiberAttribute = item.ToObject<FiberAttribute>();
                attributes.Add(fiberAttribute);
            }
            return attributes;
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
