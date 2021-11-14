namespace AzureDevTesting.Data.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
    }
}
