using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureDevTesting
{
    public static class GetJobs
    {
        [FunctionName("GetJobs")]
        public static IActionResult Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "jobs")
            ] HttpRequest req,
                ILogger log)
        {
            log.LogInformation("HTTP request: get jobs.");

            var json = JsonConvert.SerializeObject(new
            {
                jobs = new object()
            });

            return (ActionResult)new OkObjectResult(json);
        }

    }
}
