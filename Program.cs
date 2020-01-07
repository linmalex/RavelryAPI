using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RavelryAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //string endpoint = "fiber_attributes";
            string endpoint = "fiber_attribute_groups";
            RavelryRequest ravRequest = new RavelryRequest(endpoint);

            List<FiberAttribute> x = await ravRequest.ParseToFiberAttributesAsync();

        }


    }


}
