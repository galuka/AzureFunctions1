﻿namespace AzureDevTesting.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; }
        public int CityId { get; set; }
    }
}
