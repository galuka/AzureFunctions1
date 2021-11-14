using AzureDevTesting.Business.Providers.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace AzureDevTesting
{
    public class GetUsers
    {
        private readonly IUserProvider userProvider;

        public GetUsers(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        [FunctionName("GetUser")]
        public IActionResult Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "user")
            ] HttpRequest req,
                ILogger log)
        {
            log.LogInformation("HTTP request: get user.");

            var idParamValue = req.Query["id"];
            int.TryParse(idParamValue, out int id);
            if (id == 0)
            {
                throw new Exception($"Cannot parse user id from '{idParamValue}' value. Please make sure you specify 'id' query param with valid value.");
            }

            var json = JsonConvert.SerializeObject(new
            {
                users = userProvider.Get(id)
            });

            return (ActionResult)new OkObjectResult(json);
        }

    }
}
