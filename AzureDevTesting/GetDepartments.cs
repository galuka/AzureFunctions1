using AzureDevTesting.Business.Providers.Departments;
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
    public class GetDepartments : AzureFunctionsBase
    {
        private readonly IDepartmentProvider departmentProvider;

        public GetDepartments(IDepartmentProvider departmentProvider)
        {
            this.departmentProvider = departmentProvider;
        }

        [FunctionName("GetDepartment")]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "department")
            ] HttpRequest req,
                ILogger log)
        {
            log.LogInformation("HTTP request: get department.");

            var id = GetIdFromRequest(req);
            var department = await departmentProvider.Get(id);
            var json = JsonConvert.SerializeObject(department, Formatting.Indented);

            return new OkObjectResult(json);
        }
    }
}
