using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Repositories
{
    public class UserRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public UserRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public void InsertUser(User user)
        {
            _airportSystemContext.Users.Add(user);
            _airportSystemContext.SaveChanges();
        }

        public User GetUser(int userId)
        {
            return _airportSystemContext.Users.FirstOrDefault(user => user.Id.Equals(userId));
        }

        public User GetUser(string username)
        {
            return _airportSystemContext.Users.FirstOrDefault(user => user.Username == username);
        }
    }
}
