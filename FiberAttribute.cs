using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RavelryAPI
{
    [Endpoint("fiber_attribute")]
    public class FiberAttribute: RavEndpoint
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
