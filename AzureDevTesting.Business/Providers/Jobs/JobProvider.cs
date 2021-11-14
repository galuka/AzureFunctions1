using AzureDevTesting.Data.Entities;
using System.Threading.Tasks;

namespace AzureDevTesting.Business.Providers.Jobs
{
    public class JobProvider : EntityProviderBase<Job>, IJobProvider
    {
        public async Task<Job> Get(int id)
        {
            string sql = $"SELECT * FROM [Job] j LEFT JOIN Department d ON j.DepartmentId = d.Id WHERE j.Id={id}";
            var job = await QuerySingle<Job, Department>(sql, (j, d) => { j.Department = d; return j; });

            return job;
        }
    }
}
