namespace AzureDevTesting.Business.Providers
{
    public interface IEntityProvider<T>
    {
        T Get(int id);
    }
}
