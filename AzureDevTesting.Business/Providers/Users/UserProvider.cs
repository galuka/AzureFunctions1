using AzureDevTesting.Data.Entities;

namespace AzureDevTesting.Business.Providers.Users
{
    public class UserProvider : EntityProvider<User>, IUserProvider
    {
        public User Get(int id)
        {
            string sql = $"SELECT * FROM [User] u LEFT JOIN City c ON u.CityId = c.Id WHERE u.Id=1";

            return QuerySingle<User, City>(sql, (u, c) => { u.City = c; return u; });
        }
    }
}
