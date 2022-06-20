using MemoryCasheExampleApi.DTOs;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MemoryCasheExampleApi.Data
{
    public static class UserDbSimulator
    {
        public static ReadOnlyCollection<User> GetUsers()
        {
            return new List<User>
        {
            new() {FirstName = "Tim", LastName = "Corey"},
            new() {FirstName = "Sue", LastName = "Storm"},
            new() {FirstName = "Jane", LastName = "Jones"}
        }.AsReadOnly();
        }
    }
}
