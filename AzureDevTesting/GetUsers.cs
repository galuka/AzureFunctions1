using AzureDevTesting.Business.Providers.Users;
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
    public class GetUsers : AzureFunctionsBase
    {
        private readonly IUserProvider userProvider;

        public GetUsers(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        [FunctionName("GetUser")]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "user")
            ] HttpRequest req,
                ILogger log)
        {
            log.LogInformation("HTTP request: get user.");

            var id = GetIdFromRequest(req);
            var user = await userProvider.Get(id);
            var json = JsonConvert.SerializeObject(user, Formatting.Indented);

            return new OkObjectResult(json);
        }
    }
}
