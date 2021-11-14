using AzureDevTesting.Data.Entities;

namespace AzureDevTesting.Business.Providers.Cities
{
    public class CityProvider : EntityProvider<City>, ICityProvider
    {
        public City Get(int id)
        {
            string sql = $"SELECT * FROM City WHERE Id={id}";

            return QuerySingle(sql);
        }
    }
}
