using AzureDevTesting.Business.Providers.Cities;
using AzureDevTesting.Functions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AzureDevTesting
{
    public class GetCities : AzureFunctionsBase
    {
        private readonly ICityProvider cityProvider;

        public GetCities(ICityProvider cityProvider)
        {
            this.cityProvider = cityProvider;
        }

        [FunctionName("GetCity")]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "city")
            ] HttpRequest req,
                ILogger log)
        {
            log.LogInformation("HTTP request: get city.");

            var id = GetIdFromRequest(req);
            var city = await cityProvider.Get(id);
            var json = JsonConvert.SerializeObject(city, Formatting.Indented);

            return new OkObjectResult(json);
        }
    }
}
