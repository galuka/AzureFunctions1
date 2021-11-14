using AzureDevTesting.Data.Entities;
using System.Threading.Tasks;

namespace AzureDevTesting.Business.Providers.Users
{
    public class UserProvider : EntityProviderBase<User>, IUserProvider
    {
        public async Task<User> Get(int id)
        {
            string sql = $"SELECT * FROM [User] u LEFT JOIN City c ON u.CityId = c.Id LEFT JOIN [Job] j ON u.JobId = j.Id LEFT JOIN Department d ON j.DepartmentId = d.Id WHERE u.Id={id}";
            var user = await QuerySingle<User, City, Job, Department>(sql, (u, c, j, d) => { u.City = c; u.Job = j; u.Job.Department = d; return u; });

            return user;
        }
    }
}
