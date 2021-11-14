using AzureDevTesting.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AzureDevTesting
{
    public static class Database
    {
        private static List<User> users = new List<User>(){
            new User(){ Id = 1, Name= "A" , LastName = "A", Email = "a@stratiteq.com", JobId = 1, CityId = 1},
            new User(){ Id = 2, Name= "B" , LastName = "B", Email = "b@stratiteq.com", JobId = 2, CityId = 2}
        };

        private static List<Job> jobs = new List<Job>(){
            new Job(){ Id = 1, Name= "Developer" , DepartmentId = 1},
            new Job(){ Id = 2, Name= "Product manager" , DepartmentId = 2}
        };

        private static List<Department> departments = new List<Department>(){
            new Department(){ Id = 1, Name= "Development"},
            new Department(){ Id = 2, Name= "Go to market"}
        };

        private static List<City> cities = new List<City>(){
            new City(){ Id = 1, Name= "Oxie" , PostalCode = "23840", Latitude = 0.0M, Longitude = 0.0M},
            new City(){ Id = 2, Name= "Limhamn" , PostalCode = "21648", Latitude = 0.0M, Longitude = 0.0M}
        };

        public static IEnumerable<User> GetUsers()
        {
            return users.AsEnumerable();
        }
        public static IEnumerable<Job> GetJobs()
        {
            return jobs.AsEnumerable();
        }
        public static IEnumerable<Department> GetDepartments()
        {
            return departments.AsEnumerable();
        }
        public static IEnumerable<City> GetCities()
        {
            return cities.AsEnumerable();
        }
    }
}
