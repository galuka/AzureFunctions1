using AzureDevTesting.Business.Providers.Cities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace AzureDevTesting
{
    public class GetCities
    {
        private readonly ICityProvider cityProvider;

        public GetCities(ICityProvider cityProvider)
        {
            this.cityProvider = cityProvider;
        }

        [FunctionName("GetCity")]
        public IActionResult Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "city")
            ] HttpRequest req,
                ILogger log)
        {
            log.LogInformation("HTTP request: get city.");

            var idParamValue = req.Query["id"];
            int.TryParse(idParamValue, out int id);
            if (id == 0)
            {
                throw new Exception($"Cannot parse city id from '{idParamValue}' value. Please make sure you specify 'id' query param with valid value.");
            }

            var json = JsonConvert.SerializeObject(new
            {
                cities = cityProvider.Get(id)
            }) ;

            return new OkObjectResult(json);
        }
    }
}
