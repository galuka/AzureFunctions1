using AzureDevTesting.Data.Entities;
using System.Threading.Tasks;

namespace AzureDevTesting.Business.Providers.Cities
{
    public class CityProvider : EntityProviderBase<City>, ICityProvider
    {
        public async Task<City> Get(int id)
        {
            string sql = $"SELECT * FROM City WHERE Id={id}";
            var city = await QuerySingle(sql);

            return city;
        }
    }
}
