using System.Threading.Tasks;

namespace AzureDevTesting.Business.Providers
{
    public interface IEntityProvider<T>
    {
        Task<T> Get(int id);
    }
}
