using AzureDevTesting.Data.Entities;
using System.Threading.Tasks;

namespace AzureDevTesting.Business.Providers.Departments
{
    public class DepartmentProvider : EntityProviderBase<Department>, IDepartmentProvider
    {
        public async Task<Department> Get(int id)
        {
            string sql = $"SELECT * FROM Department WHERE Id={id}";
            var department = await QuerySingle(sql);

            return department;
        }
    }
}
