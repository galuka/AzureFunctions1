using AzureDevTesting.Business.Providers.Cities;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureDevTesting.Functions.Startup))]
namespace AzureDevTesting.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<ICityProvider, CityProvider>();            
        }
    }
}
