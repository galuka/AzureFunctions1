using AzureDevTesting.Business.Providers.Jobs;
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
    public class GetJobs : AzureFunctionsBase
    {
        private readonly IJobProvider jobProvider;

        public GetJobs(IJobProvider jobProvider)
        {
            this.jobProvider = jobProvider;
        }

        [FunctionName("GetJob")]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "job")
            ] HttpRequest req,
                ILogger log)
        {
            log.LogInformation("HTTP request: get job.");

            var id = GetIdFromRequest(req);
            var job = await jobProvider.Get(id);
            var json = JsonConvert.SerializeObject(job, Formatting.Indented);

            return new OkObjectResult(json);
        }

    }
}
